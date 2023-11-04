using UnityEngine;
using UnityEngine.UI;
using TMPro; // Include the namespace for TextMeshPro

public class SelectAndWalk : MonoBehaviour
{/* 
    // The gameobject that is currently selected
    private GameObject selectedObject;

    // The UI text element that shows the prompt
    public TextMeshProUGUI promptText; // Change the type from Text to TextMeshProUGUI

    // The distance threshold for walking over
    public float walkDistance = 5f;

    // The speed of walking over
    public float walkSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        // If the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left mouse button clicked"); // Add a debug statement
            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Perform a raycast and store the hit information
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Raycast hit an object: " + hit.collider.name); // Add a debug statement
                // If the hit object has a collider
                if (hit.collider != null)
                {
                    // Deselect the previous object if any
                    if (selectedObject != null)
                    {
                        selectedObject.GetComponent<Renderer>().material.color = Color.white;
                    }

                    // Select the new object and change its color to green
                    selectedObject = hit.collider.gameObject;
                    selectedObject.GetComponent<Renderer>().material.color = Color.green;

                    // Show the prompt text
                    promptText.text = "Right-click to walk over";
                }
            }
        }

        // If the right mouse button is clicked and an object is selected
        if (Input.GetMouseButtonDown(1) && selectedObject != null)
        {
            Debug.Log("Right mouse button clicked"); // Add a debug statement
            // Hide the prompt text
            promptText.text = "";

            // Get the direction vector from the camera to the object
            Vector3 direction = selectedObject.transform.position - Camera.main.transform.position;

            // Get the distance from the camera to the object
            float distance = direction.magnitude;
            Debug.Log("Distance from camera to object: " + distance); // Add a debug statement

            // If the distance is greater than the threshold
            if (distance > walkDistance)
            {
                Debug.Log("Distance is greater than threshold"); // Add a debug statement
                // Move the camera towards the object by a fraction of the distance
                Camera.main.transform.position += direction.normalized * walkSpeed * Time.deltaTime;
            }
        }
    } */
}
