using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Linq;

// The model class that stores the data and state of the cursor
public class CursorModel : MonoBehaviour
{
    // The model instance
    private CursorModel instance;

    // Initialize the instance
    private void Awake()
    {
        instance = GetComponent<CursorModel>();
    }

    // The last clicked ZimObject
    public ZimObject LastClickedObject { get; set; }

    // The last hovered ZimObject
    public ZimObject LastHoveredObject { get; set; }

    // The object prompt GameObject
    public GameObject ObjectPrompt { get; set; }
}
