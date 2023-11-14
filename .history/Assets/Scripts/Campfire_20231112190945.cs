using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class Campfire : Interactable
{
    [SerializeField]private float heatRemaining;
    [SerializeField]private float maxHeat;
    [SerializeField]private float warningThreshold;
    [SerializeField]private float heatRange;

    [SerializeField]private float cookTime;

    [SerializeField]private SpriteRenderer heatIndicator;

    private float indicatorAlpha;
    private float maxAlpha;
    private bool cooking;
    private float cookingProgress;

    void Start()
    {
        indicatorAlpha = heatIndicator.color.a;
        maxAlpha = indicatorAlpha;
        heatIndicator.transform.localScale = new Vector3(heatRange * 2, heatRange * 2, 1f);
    }

    void Update()
    {
        if (heatRemaining < warningThreshold) 
        {
            indicatorAlpha = heatRemaining / warningThreshold * maxAlpha;
        } 
        else
        {
            indicatorAlpha = maxAlpha;
        }
        
        Color c = heatIndicator.color;
        heatIndicator.color = new Color(c.r, c.g, c.b, indicatorAlpha);

        if (heatRemaining > 0)
        {
            heatRemaining -= Time.deltaTime;
        }

        if (cookingProgress < cookTime && cooking)
    }

    public override void Interact(PlayerController caller)
    {
        base.Interact(caller);
        if (caller.heldItem == null)
        {
            return;
        }

        if (caller.heldItem.CompareTag("Wood"))
        {
            Wood wood = caller.heldItem.GetComponent<Wood>();
            AddWood(wood.AddedHeat());
            caller.ConsumeItem();
        }
        else if (caller.heldItem.CompareTag("Meat")) 
        {
            Meat meat = caller.heldItem.GetComponent<Meat>();
            cooking = true;
        }
    }

    public void AddWood(float heatAdded)
    {
        float addable = maxHeat - heatRemaining;
        if (addable > heatAdded)
        {
            heatRemaining += heatAdded;
        } else
        {
            heatRemaining += addable;
        }
    }

    private void Cook() 
    {
        
    }

    public bool Burning()
    {
        return heatRemaining > 0;
    }

    public float HeatRange()
    {
        return heatRange;
    }
}
