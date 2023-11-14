using UnityEngine;

public abstract class Item : Interactable
{
    [SerializeField] private bool isHeavy;
    [SerializeField] private bool usable;
    [SerializeField] private bool canInteract = true;

    public override void Interact(PlayerController caller) {
        if (canInteract)
        {
            base.Interact(caller);
            PickupItem(caller);
        }
    }

    public virtual void PickupItem(PlayerController caller)
    {
        caller.PickupItem(this);
        canInteract = false;
    }

    public virtual void DropItem() 
    {
        Invoke(nameof(Cooldown), 0.5f);
    }

    public virtual void UseItem() 
    {
        if (!usable)
            return;
    }

    public bool IsHeavy() 
    { 
        return isHeavy;
    }

    private void Cooldown()
    {
        canInteract = true;
    }
}
