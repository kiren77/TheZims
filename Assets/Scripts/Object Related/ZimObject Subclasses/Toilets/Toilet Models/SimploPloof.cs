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
            //call the OnStateChanged method to raise the event
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
        //call the OnStateChanged method to raise the event
        OnStateChanged();
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
        //call the OnStateChanged method to raise the event
        OnStateChanged();
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
        //call the OnStateChanged method to raise the event
        OnStateChanged();
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
        //call the OnStateChanged method to raise the event
        OnStateChanged();
    }
    else
    {
        Debug.Log("SimploPloof does not need repairing.");
    }
}



public override void Interact(string prompt)
{
    //try to get the action from the dictionary
    if (actions.TryGetValue(prompt, out System.Action action))
    {
        //invoke the action if it is not null
        action?.Invoke();
    }
    else
    {
        //handle the case when the prompt is not valid
        Debug.Log("Invalid prompt.");
    }
}





 public override List<string> GetAvailablePrompts()
{
    List<string> prompts = new List<string>();

    if (IsUsable) prompts.Add(nameof(Use));
    if (CanFlush) prompts.Add(nameof(Flush));
    if (NeedsCleaning) prompts.Add(nameof(Clean));
    if (IsClogged) prompts.Add(nameof(Unclog));
    if (IsBroken) prompts.Add(nameof(Repair));

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
