using UnityEngine;
using System;

using TMPro;

// A class that holds the data of the clicked ZimObject
public class ZimObjectClickedEventArgs : EventArgs
{
    // The reference to the clicked ZimObject
    public ZimObject ClickedZimObject { get; }

    // The constructor that takes the clicked ZimObject as a parameter
    public ZimObjectClickedEventArgs(ZimObject clickedZimObject)
    {
        ClickedZimObject = clickedZimObject;
    }
}

// A delegate that defines the event handler for the ZimObjectClicked event
public delegate void ZimObjectClickedEventHandler(object sender, ZimObjectClickedEventArgs e);


public class PromptManager : MonoBehaviour
{
    public GameObject promptDisplay;

    public void DisplayPrompt(ZimObject zimObject)
    {
        // Use the null-conditional operator to simplify null checks
        promptDisplay?.SetActive(true);

        // Use the null-conditional operator to simplify null checks
        TMP_Text textComponent = promptDisplay?.GetComponentInChildren<TMP_Text>();
        if (textComponent != null)
        {
            textComponent.text = $"Interactions: {string.Join(", ", zimObject.GetAvailablePrompts())}\nState: {zimObject.GetState()}";
        }

        Debug.Log($"State: {zimObject.GetState()}\nInteractions: {string.Join(", ", zimObject.GetAvailablePrompts())}");
    }
}