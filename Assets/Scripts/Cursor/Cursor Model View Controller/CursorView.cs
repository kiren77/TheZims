using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Linq;
// The view class that handles the visual aspects of the cursor
[RequireComponent(typeof(CursorModel))]

public class CursorView : MonoBehaviour
{
    // The model reference
    private CursorModel model;

    // The controller reference
    private CursorController controller;

    // Initialize the references
    private void Awake()
    {
        model = GetComponent<CursorModel>();
        controller = GetComponent<CursorController>();
    }

    // Update the view based on the model state
    private void Update()
    {

        if (model.LastClickedObject != null && model.ObjectPrompt != null)
        {
            model.ObjectPrompt.SetActive(true);

            TMP_Text textComponent = model.ObjectPrompt.GetComponentInChildren<TMP_Text>();
            if (textComponent != null)
            {
                textComponent.text = $"Interactions: {string.Join(", ", model.LastClickedObject.GetAvailablePrompts())}\nState: {model.LastClickedObject.GetState()}";
            }
        }
        else if (model.ObjectPrompt != null)
        {
            model.ObjectPrompt.SetActive(false);
        }
    }

    // Draw a debug ray from the cursor position
    public void DrawDebugRay(Vector2 position, Vector2 direction, Color color, float duration)
    {
        Debug.DrawRay(position, direction * 10, color, duration);
    }
}
