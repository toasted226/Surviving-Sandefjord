using Unity.VisualScripting;
using UnityEngine;

public class Campfire : Interactable
{
    [SerializeField]private float heatRemaining;
    [SerializeField]private float maxHeat;
    [SerializeField]private float warningThreshold;
    [SerializeField]private float heatPerLog;
    [SerializeField]private float heatRange;

    [SerializeField]private SpriteRenderer heatIndicator;

    private float indicatorAlpha;

    void Start()
    {
        heatRemaining = maxHeat / 3;
        indicatorAlpha = heatIndicator.color.a;
        heatIndicator.transform.localScale = new Vector3(heatRange * 2, heatRange * 2, 1f);
    }

    void Update()
    {
        if (heatRemaining < warningThreshold) 
        {
            Color c = heatIndicator.color;
            indicatorAlpha = heatRemaining / warningThreshold * 255f;
            heatIndicator.color = new Color(c.r, c.g, c.b, indicatorAlpha);
        }

        if (heatRemaining > 0)
        {
            heatRemaining -= Time.deltaTime;
        }
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
            caller.ConsumeItem();
            AddWood();
        }
    }

    public void AddWood()
    {
        float addable = maxHeat - heatRemaining;
        if (addable > heatPerLog)
        {
            heatRemaining += heatPerLog;
        } else
        {
            heatRemaining += addable;
        }
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
