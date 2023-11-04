using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonCreator : MonoBehaviour
{
    private ZimObject zimObject;
    public Button buttonPrefab;
    public Canvas canvas;
    public CursorController cursorController;
    private List<Button> buttons = new List<Button>();

    //declare the gameView, center, and radius variables
    private GameObject gameView;
    private GameObject center;
    private float radius;

    private void Start()
    {
        //assign the gameView variable to the Main Camera
        gameView = Camera.main.gameObject;
        //assign the center variable to a new empty game object
        center = new GameObject("Center");
        //assign the radius variable to a fixed value
        radius = 1f;
    }

    private void OnEnable()
    {
        cursorController.ZimObjectClicked += OnZimObjectClicked;
    }

    private void OnDisable()
    {
        cursorController.ZimObjectClicked -= OnZimObjectClicked;
    }

   private void OnZimObjectClicked(object sender, ZimObjectClickedEventArgs e)
{
    //check if the ClickedZimObject is not null
    if (e.ClickedZimObject != null)
    {
        zimObject = e.ClickedZimObject;
        CreateButtons(zimObject);
        //set the center to the clicked ZimObject's position
        center.transform.position = zimObject.transform.position;
        //call the ArrangeButtons method to update the positions of the buttons
        ArrangeButtons();
    }
    else
    {
        Debug.LogError("No ZimObject was clicked");
    }
}

    public void CreateButtons(ZimObject zimObject)
    {
        foreach (Button button in buttons)
        {
            Destroy(button.gameObject);
        }

        buttons.Clear();

        if (zimObject != null)
        {
            List<string> prompts = zimObject.GetAvailablePrompts();

            foreach (string prompt in prompts)
            {
                Button newButton = Instantiate(buttonPrefab, canvas.transform);
                newButton.GetComponentInChildren<Text>().text = prompt;
                newButton.onClick.AddListener(() => zimObject.Interact(prompt));
                buttons.Add(newButton);
            }
        }
    }

    public void ArrangeButtons()
    {
        //get the up and right vectors from the gameView object so we can orient the buttons
        Vector3 up = gameView.transform.up;
        Vector3 right = gameView.transform.right;

        //get the angle between each button, assuming equal spacing
        float angle = 360f / buttons.Count;

        //loop through the buttons and set their positions
        for (int i = 0; i < buttons.Count; i++)
        {
            //convert degrees to radians
            float rad = Mathf.Deg2Rad * angle * i;

            //calculate the position using trigonometry
            Vector3 pos = center.transform.position + (radius * right * Mathf.Cos(rad)) + (radius * up * Mathf.Sin(rad));

            //set the position of the button
            buttons[i].transform.position = pos;
        }
    }
}
