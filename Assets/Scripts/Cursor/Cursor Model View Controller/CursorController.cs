using UnityEngine;
using System.Collections.Generic;

//a script that handles the input and logic of the cursor
[RequireComponent(typeof(CursorModel))]
public class CursorController : MonoBehaviour
{
    // The model reference
    private CursorModel model;

    // The view reference
    private CursorView view;

    // A reference to the PromptManager script
    [SerializeField] private PromptManager promptManager;

    // An event that is raised when a ZimObject is clicked
    public event ZimObjectClickedEventHandler ZimObjectClicked;


    
    // Initialize the references
    private void Awake()
    {
        model = GetComponent<CursorModel>();
        view = GetComponent<CursorView>();
    }

        // A method that raises the ZimObjectClicked event internally
    public void RaiseZimObjectClicked(object sender, ZimObjectClickedEventArgs e)
    {
        //invoke the event if it is not null
        ZimObjectClicked?.Invoke(sender, e);
    }

    // Handle the ZimObjectClicked event
    private void OnZimObjectClicked(object sender, ZimObjectClickedEventArgs e)
    {
        //get the clicked ZimObject from the event args
        ZimObject zimObject = e.ClickedZimObject;

        //log the information about the clicked ZimObject
        Debug.Log($"Clicked on {zimObject.name}");
        Debug.Log($"Name: {zimObject.Data.ObjectName}\n" +
                  $"Description: {zimObject.Data.ObjectDescription}\n" +
                  $"Price: {zimObject.Data.ObjectPrice}\n" +
                  $"State: {zimObject.GetState()}");

        //get the available prompts from the clicked ZimObject
        List<string> prompts = zimObject.GetAvailablePrompts();
        string promptsString = string.Join(", ", prompts);
        Debug.Log($"Actions: {promptsString}");

        //invoke an action on the clicked ZimObject
        InvokeAction(zimObject);

        //display the prompt for the clicked ZimObject
        promptManager.DisplayPrompt(zimObject);
    }

    // Invoke an action on a ZimObject
    private void InvokeAction(ZimObject zimObject)
    {
        // TODO: Implement the logic for invoking actions on ZimObjects
    }
}
