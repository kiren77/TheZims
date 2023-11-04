using UnityEngine;
using TMPro;

public class PromptManager : MonoBehaviour
{
    public GameObject objectPrompt;

    public void DisplayPrompt(ZimObject zimObject)
    {
        if (objectPrompt != null)
        {
            objectPrompt.SetActive(true);

            TMP_Text textComponent = objectPrompt.GetComponentInChildren<TMP_Text>();
            if (textComponent != null)
            {
                textComponent.text = $"Interactions: {string.Join(", ", zimObject.GetAvailablePrompts())}\nState: {zimObject.GetState()}";
            }

            Debug.Log($"State: {zimObject.GetState()}\nInteractions: {string.Join(", ", zimObject.GetAvailablePrompts())}");
        }
    }
}