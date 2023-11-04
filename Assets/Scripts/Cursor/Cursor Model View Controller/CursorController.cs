using UnityEngine;
using System.Collections.Generic;

// A script that handles the input and logic of the cursor
[RequireComponent(typeof(CursorModel))]
public class CursorController : MonoBehaviour
{
    // The model reference
    private CursorModel model;

    // The view reference
    private CursorView view;

    // Initialize the references
    private void Awake()
    {
        model = GetComponent<CursorModel>();
        view = GetComponent<CursorView>();
    }

    // Handle the cursor input based on collisions
    private void Update()
    {
        RaycastHit2D hit = GetCursorHit();
        
        if (hit.collider != null)
        {
            ZimObject zimObject = hit.collider.GetComponent<ZimObject>();

            if (zimObject != null && !zimObject.isBeingUsed)
            {
                // Update the last hovered object in the model
                if (zimObject != model.LastHoveredObject)
                {
                    model.LastHoveredObject = zimObject;
                }

                // Handle mouse click on a ZimObject
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log($"Clicked on {zimObject.name}");

                    // Update the last clicked object in the model
                    if (model.LastClickedObject != null && model.LastClickedObject != zimObject && model.ObjectPrompt != null)
                    {
                        model.ObjectPrompt.SetActive(false);
                    }

                    model.LastClickedObject = zimObject;

                    Debug.Log($"Name: {zimObject.Data.ObjectName}\n" +
                              $"Description: {zimObject.Data.ObjectDescription}\n" +
                              $"Price: {zimObject.Data.ObjectPrice}\n" +
                              $"State: {zimObject.GetState()}");

                    // Get the available prompts from the ZimObject
                    List<string> prompts = zimObject.GetAvailablePrompts();

                    // Convert the list to a comma-separated string
                    string promptsString = string.Join(", ", prompts);

                    // Log the prompts
                    Debug.Log($"Actions: {promptsString}");

                    // Invoke an action on the ZimObject
                    InvokeAction(zimObject);
                }
            }
            else
            {
                Debug.Log("Hit object does not have a ZimObject component");
            }
        }
        else
        {
            // Handle mouse click on empty space
            if (Input.GetMouseButtonDown(0))
            {
                if (model.ObjectPrompt != null)
                {
                    model.ObjectPrompt.SetActive(false);
                }

                model.LastClickedObject = null;
            }
        }
    }

    // Get the cursor hit using raycast
    private RaycastHit2D GetCursorHit()
    {
        Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
        view.DrawDebugRay(position, Vector2.up, Color.red, 0.1f);

        return hit;
    }

    // Invoke an action on a ZimObject
    private void InvokeAction(ZimObject zimObject)
    {
        // TODO: Implement the logic for invoking actions on ZimObjects
    }
}
