using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// A script that creates button prefabs for the interactions of a ZimObject
public class ButtonCreator : MonoBehaviour
{
    // A reference to the ZimObject
    public ZimObject zimObject;

    // A reference to the button prefab
    public Button buttonPrefab;

    // A reference to the canvas
    public Canvas canvas;

    // A list of buttons
    private List<Button> buttons;

    // A method that creates the buttons
    public void CreateButtons()
    {
        // Clear the existing buttons
        if (buttons != null)
        {
            foreach (Button button in buttons)
            {
                Destroy(button.gameObject);
            }
        }

        // Initialize the buttons list
        buttons = new List<Button>();

        // Get the available prompts from the ZimObject
        List<string> prompts = zimObject.GetAvailablePrompts();

        // Loop through the prompts list
        foreach (string prompt in prompts)
        {
            // Instantiate a button prefab
            Button newButton = Instantiate(buttonPrefab, canvas.transform);

            // Set the button text to the prompt
            newButton.GetComponentInChildren<Text>().text = prompt;

            // Add a listener to the button click event
            newButton.onClick.AddListener(() => 
            {
                // Call the Interact method of the ZimObject with the prompt as the parameter
                zimObject.Interact(prompt);
            });

            // Add the button to the list
            buttons.Add(newButton);
        }
    }
}
