using UnityEngine;

public class Campfire : Interactable
{
    [SerializeField]private float heatRemaining;
    [SerializeField]private float maxHeat;
    [SerializeField]private float heatPerLog;
    [SerializeField]private float heatRange;

    void Start()
    {
        heatRemaining = maxHeat / 3;
    }

    void Update()
    {
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
