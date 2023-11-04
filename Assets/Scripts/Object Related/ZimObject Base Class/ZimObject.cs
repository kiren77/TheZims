using System;
using System.Collections.Generic;
using UnityEngine;

public class ZimData
{
    public string ObjectName { get; set; }
    public string ObjectDescription { get; set; }
    public int ObjectPrice { get; set; }
    public Sprite ThisSprite { get; set; }
} 

public interface IObservable
{
     event Action StateChanged;
    string GetState();
    List<string> GetAvailablePrompts(); 
}

/* [DebuggerDisplay("State = {GetState()}, Interactions = {string.Join(\", \", GetAvailablePrompts())}")]
 */
 public abstract class ZimObject: MonoBehaviour, IObservable
{
    public ZimData Data { get; set; }

    public event Action StateChanged;

    protected SpriteRenderer spriteRenderer;
    private new Collider2D collider2D;

    // The original sprite color
    private Color originalColor;

    // The hover sprite color
    public Color hoverColor;



    public bool isBeingUsed { get; set; }

    protected virtual void Start()
    {
        InitializeComponents();
        AssignSprite();
        originalColor = spriteRenderer.color; // Store the original color

    }

    private void InitializeComponents()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
    }

    private void AssignSprite()
{
    if (Data != null && Data.ThisSprite != null)
    {
        spriteRenderer.sprite = Data.ThisSprite;
    }
}

    private void OnMouseEnter()
    {
        spriteRenderer.color = hoverColor; // Change to hover color
    }

    private void OnMouseExit()
    {
        spriteRenderer.color = originalColor; // Change back to original color
    }

    public abstract void Interact(string interaction);
    
    public virtual List<string> GetAvailablePrompts()
    {
        return new List<string>();
    }

    public virtual string GetState()
    {
        return "Default state";
    }

protected void OnStateChanged()
{
    // Invoke the event here
    StateChanged?.Invoke();
}

}
