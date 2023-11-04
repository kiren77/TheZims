using UnityEngine;
using UnityEngine.UI;

public class ObjectActionsPopulator : MonoBehaviour
{
    // Reference to the prefab for the action buttons
    public GameObject actionButtonPrefab;

    // Reference to the object prompt panel
    public GameObject objectPrompt;

    public void PopulateActions(ZimObject zimObject)
    {
        // First, clear out any existing action buttons
        foreach (Transform child in objectPrompt.transform)
        {
            Destroy(child.gameObject);
        }

        // Then, create a new action button for each interaction
        // This line is causing an error because GetInteractions is not defined in ZimObject
        // foreach (string interaction in zimObject.GetInteractions())
        // Uncomment this line and implement GetInteractions method in ZimObject or use a different method
        foreach (string interaction in zimObject.GetAvailablePrompts())
        {
            GameObject actionButton = Instantiate(actionButtonPrefab, objectPrompt.transform);
            actionButton.GetComponentInChildren<Text>().text = interaction;
            actionButton.GetComponent<Button>().onClick.AddListener(() => zimObject.Interact(interaction));
        }
    }
}
