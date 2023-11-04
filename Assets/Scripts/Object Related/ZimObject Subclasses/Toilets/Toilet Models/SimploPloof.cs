using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class SimploPloof : ZimObject, IToilet
{
    private int useCount;
    private Dictionary<string, System.Action> actions;

    public bool IsUsable => (useCount & 1) == 0 || CanFlush || NeedsCleaning;
    public bool CanFlush => (useCount & 2) == 2 && (useCount & 4) == 0;
    public bool NeedsCleaning => (useCount & 4) == 4 && (useCount & 8) == 0;
    public bool IsClogged => (useCount & 8) == 8;
    public bool IsBroken { get; private set; }

 

    protected override void Start()
    {
        Data = new ZimData
        {
            ObjectName = "SimploPloof",
            ObjectDescription = "A basic toilet with limited features",
            ObjectPrice = 500,
            ThisSprite = null // Set this to the sprite for the SimploPloof
        };

        base.Start();
        useCount = 0;
        IsBroken = false;

        actions = new Dictionary<string, System.Action>
        {
            { "Use", () => Use() },
            { "Flush", () => Flush() },
            { "Clean", () => Clean() },
            { "Unclog", () => Unclog() },
            { "Repair", () => Repair() }
        };
    }

    public void Use()
{
    if (IsUsable)
    {
        Debug.Log("Using SimploPloof...");
        useCount++;
        if (Random.Range(0, 10) == 0)
        {
            Debug.Log("SimploPloof broke!");
            IsBroken = true;
            // Call the method here instead of invoking the event directly
            OnStateChanged();
        }
    }
    else
    {
        Debug.Log("SimploPloof is not usable right now.");
    }
}


    public void Flush()
    {
        if (CanFlush)
        {
            Debug.Log("Flushing SimploPloof...");
            useCount = 0;
        }
        else
        {
            Debug.Log("SimploPloof does not need flushing right now.");
        }
    }

    public void Clean()
    {
        if (NeedsCleaning)
        {
            Debug.Log("Cleaning SimploPloof...");
            useCount = 0;
        }
        else
        {
            Debug.Log("SimploPloof does not need cleaning right now.");
        }
    }

    public void Unclog()
    {
        if (IsClogged)
        {
            Debug.Log("Unclogging SimploPloof...");
            useCount = 4;
        }
        else
        {
            Debug.Log("SimploPloof is not clogged.");
        }
    }

    public void Repair()
    {
        if (IsBroken)
        {
            Debug.Log("Repairing SimploPloof...");
            IsBroken = false;
            useCount = 0;
        }
        else
        {
            Debug.Log("SimploPloof does not need repairing.");
        }
    }

 public override void Interact(string interaction)
{
    switch (interaction)
    {
        case "Use":
            Use();
            break;
        case "Flush":
            Flush();
            break;
        case "Clean":
            Clean();
            break;
        case "Unclog":
            Unclog();
            break;
        case "Repair":
            Repair();
            break;
        default:
            Debug.Log("Invalid interaction.");
            break;
    }
}




    // Replace the new keyword with the override keyword
    public override List<string> GetAvailablePrompts()
    {
        List<string> prompts = new List<string>();

        if (IsUsable) prompts.Add("Use");
        if (CanFlush) prompts.Add("Flush");
        if (NeedsCleaning) prompts.Add("Clean");
        if (IsClogged) prompts.Add("Unclog");
        if (IsBroken) prompts.Add("Repair");

        return prompts;
    }

public override string GetState()
{
    if (IsBroken) return "Broken";
    if (IsClogged) return "Clogged";
    if (NeedsCleaning) return "Dirty";
    if (CanFlush) return "Flushed";
    return "Usable";
}



}
