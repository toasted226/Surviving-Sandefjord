using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : Item
{
    [SerializeField]

    public override void Interact(PlayerController caller)
    {
        base.Interact(caller);
    }

    public override void PickupItem(PlayerController caller)
    {
        base.PickupItem(caller);
    }

    public override void DropItem()
    {
        base.DropItem();
    }

    public override void UseItem()
    {
        base.UseItem();
    }
}
