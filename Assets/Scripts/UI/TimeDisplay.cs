
using UnityEngine;
using TMPro;

public class TimeDisplay : MonoBehaviour {

    public TMP_Text currentTimeText; // A reference to the UI text element that displays the time

    private Clock clock; // A reference to the Clock script

    void Start () {
        // Get a reference to the Clock script on the same game object
        clock = GetComponent<Clock> ();
    }

    void Update () {
        // Display the current time from the Clock script on the UI text element
        currentTimeText.text = clock.CurrentTime;

    }
}