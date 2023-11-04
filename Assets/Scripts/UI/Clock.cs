using UnityEngine;

public class Clock : MonoBehaviour {

    public float timeScale = 60f; // A factor that determines how fast the game time passes compared to real time

    
    private float gameTime = 0f; // A variable that stores the game time in seconds

    [SerializeField]
    private float customTime = 1234; // Military time that the game time will be set to in the inspector

  // A method that takes the customTime value and calculates the gameTime value
    [ContextMenu("Set Game Time")]
    private void SetGameTime () {
        gameTime = customTime * 3600;
    }

    private int hours; // A variable that stores the hours of the game time
    private int minutes; // A variable that stores the minutes of the game time
    private string amPm; // A variable that stores the AM/PM indicator of the game time

    void Start () {
        
    }

    void Update () {
        // Increase the game time by the scaled delta time
        gameTime += Time.deltaTime * timeScale;
        // Calculate the hours and minutes from the game time using modulus and division operations
        hours = (int) (gameTime / 3600f) % 24;
        minutes = (int) (gameTime / 60f) % 60;
        // Calculate the AM/PM indicator from the hours using a conditional operator
        amPm = hours < 12 ? "AM" : "PM";
        // Adjust the hours to 12-hour format by subtracting 12 if greater than 12 and replacing 0 with 12
        if (hours > 12) hours -= 12;
        if (hours == 0) hours = 12;
    }

    
    public string CurrentTime {
        get {
            // Format the time using a string interpolation and a leading zero for single digits
            return $"{hours:00}:{minutes:00} {amPm}";
        }
    }

    // A method that parses the CurrentTime property and converts it to the gameTime variable
    [ContextMenu("Set Current Time")]
    private void SetCurrentTime () {
        // Declare a DateTime variable to store the parsed time
        System.DateTime parsedTime;
        // Try to parse the CurrentTime property with a specific format and culture
        if (System.DateTime.TryParseExact(CurrentTime, "hh:mm tt", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedTime)) {
            // If successful, get the total number of seconds from the parsed time
            gameTime = (float)parsedTime.TimeOfDay.TotalSeconds;
        } else {
            // If not successful, print an error message to the console
            Debug.LogError("Invalid time format. Please use hh:mm AM/PM.");
        }
    }
}
