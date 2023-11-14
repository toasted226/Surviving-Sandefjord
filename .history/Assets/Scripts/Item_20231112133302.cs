using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : Interactable
{
    [SerializeField]private bool isHeavy;
    [SerializeField]private bool canInteract = true;

    public override void Interact(PlayerController caller) {
        if (canInteract)
        {
            base.Interact(caller);
            PickupItem(caller);
        }
    }

    public void PickupItem(PlayerController caller)
    {
        caller.PickupItem(this);
        canInteract = false;
    }

    public void DropItem() 
    {
        Invoke(nameof(Cooldown), 0.5f);
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
