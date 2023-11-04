using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NeedsManager : MonoBehaviour {/* 

    // An enum to represent the different types of needs
    public enum NeedType {
        Hunger, 
        Social,
        Fun, // last of the ones currently implemented
        Energy, 
        Bladder,
        Hygiene,
        
        Comfort,
        Environment


    }

    // A class to store the information of each need
    [System.Serializable]
    public class Need {
        public string name; // The name of the need
        public float value; // The current value of the need
        public float maxValue; // The maximum value of the need
        public float decayRate; // The rate at which the need decays over time
        public List<string> fulfillmentMethods; // A list of methods that can fulfill the need

        // A constructor to initialize the need with some default values
        public Need (string name, float maxValue, float decayRate) {
            this.name = name;
            this.maxValue = maxValue;
            this.decayRate = decayRate;
            this.value = maxValue; // Start with full value
            this.fulfillmentMethods = new List<string> (); // Start with an empty list
        }

        // A method to add a fulfillment method to the list
        public void AddFulfillmentMethod (string method) {
            this.fulfillmentMethods.Add (method);
        }

        // A method to check if a given method can fulfill the need
        public bool CanFulfill (string method) {
            return this.fulfillmentMethods.Contains (method);
        }
    }

    // A list or an array of Need objects
    public List<Need> needs;

    // A dictionary to map each NeedType to its corresponding Need object
    private Dictionary<NeedType, Need> needsDictionary;

    // Use this for initialization
    void Start () {
        // Initialize the needs list or array with some default values
        needs = new List<Need> ();
        needs.Add (new Need ("Hunger", 100f, 0.1f)); // Add Hunger need with max value 100 and decay rate 0.1
        needs.Add (new Need ("Social", 100f, 0.05f)); // Add Social need with max value 100 and decay rate 0.05
        needs.Add (new Need ("Fun", 100f, 0.08f)); // Add Fun need with max value 100 and decay rate 0.08
        // Add needs for Energy, Bladder, Hygiene, Entertainment, Trash, Environment
        needs.Add (new Need ("Energy", 100f, 0.1f));
        needs.Add (new Need ("Bladder", 100f, 0.1f));
        needs.Add (new Need ("Hygiene", 100f, 0.1f));
        needs.Add (new Need ("Entertainment", 100f, 0.1f));
        needs.Add (new Need ("Trash", 100f, 0.1f));
        needs.Add (new Need ("Environment", 100f, 0.1f));

        // Initialize the fulfillment methods for each need
        needs[0].AddFulfillmentMethod ("Eat"); // Add Eat method to Hunger need
        needs[1].AddFulfillmentMethod ("Talk"); // Add Talk method to Social need
        needs[2].AddFulfillmentMethod ("Watch"); // Add Watch method to Fun need
        // Add fulfillment methods for Energy, Bladder, Hygiene, Entertainment, Trash, Environment
        needs[3].AddFulfillmentMethod ("Sleep");
        needs[4].AddFulfillmentMethod ("Toilet");
        needs[5].AddFulfillmentMethod ("Shower");
        needs[6].AddFulfillmentMethod ("Play");
        needs[7].AddFulfillmentMethod ("Throw");
        needs[8].AddFulfillmentMethod ("Clean");

        // Initialize the needs dictionary
        needsDictionary = new Dictionary<NeedType, Need> ();
        for (int i = 0; i < needs.Count; i++) {
            // Map each NeedType to its corresponding Need object
            needsDictionary.Add ((NeedType) i, needs[i]);
        }
    }

    // Update is called once per frame
    void Update () {
        // Update the needs over time
        UpdateNeeds ();
        // Check the mood of the zim character
        CheckMood ();
    }

    // A method to update the needs over time
    private void UpdateNeeds () {
        for (int i = 0; i < needs.Count; i++) {
            // Decrease the value of each need based on its decay rate
            needs[i].value -= needs[i].decayRate * Time.deltaTime;
            // Clamp the value between 0 and max value
            needs[i].value = Mathf.Clamp (needs[i].value, 0f, needs[i].maxValue);
        }
    }

    // A method to fulfill a given need based on a given method
    public void FulfillNeed (NeedType type, string method) {
        // Get the need object from the dictionary
        Need need = needsDictionary[type];
        // Check if the method can fulfill the need
        if (need.CanFulfill (method)) {
            // Increase the value of the need by some amount
            need.value += 10f;
            // Clamp the value between 0 and max value
            need.value = Mathf.Clamp (need.value, 0f, need.maxValue);
            // Print a message to the console for debugging purposes
            Debug.Log ("Fulfilled " + need.name + " by " + method);
        }
    }

    // A method to check the mood of the zim character based on the average value of all the needs
    private void CheckMood () {
        // Calculate the average value of all the needs
        float averageValue = 0f;
        for (int i = 0; i < needs.Count; i++) {
            averageValue += needs[i].value;
        }
        averageValue /= needs.Count;

        // Change the appearance or behavior of the zim character based on the average value
        if (averageValue > 80f) {
            // The zim character is very happy
            // Do something here, such as changing the sprite or playing an animation
        } else if (averageValue > 60f) {
            // The zim character is happy
            // Do something here, such as changing the sprite or playing an animation
        } else if (averageValue > 40f) {
            // The zim character is neutral
            // Do something here, such as changing the sprite or playing an animation
        } else if (averageValue > 20f) {
            // The zim character is sad
            // Do something here, such as changing the sprite or playing an animation
        } else {
            // The zim character is very sad
            // Do something here, such as changing the sprite or playing an animation
        }
    } */
}
