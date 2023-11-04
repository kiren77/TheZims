
using UnityEngine;
using System.Collections.Generic;
//a script that handles the mouse click on a ZimObject
public class ZimObjectClickHandler : MonoBehaviour
{
    //a reference to the CursorController script
    [SerializeField] private CursorController cursorController;

    //a reference to the ZimObject component
    private ZimObject zimObject;

    //initialize the references
    private void Awake()
    {
        zimObject = GetComponent<ZimObject>();
    }

    //handle the mouse click on this ZimObject
    private void OnMouseDown()
    {
        //check if the ZimObject is not being used
        if (!zimObject.isBeingUsed)
        {
                        //call the RaiseZimObjectClicked method on the CursorController script
            cursorController.RaiseZimObjectClicked(this, new ZimObjectClickedEventArgs(zimObject));        }
    }
}
