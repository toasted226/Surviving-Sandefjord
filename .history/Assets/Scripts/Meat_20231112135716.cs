using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : Item
{
    [SerializeField] private bool isCooked;
    public override void UseItem()
    {
        if (isCooked) 
        {
            base.UseItem();
        }
    }
}
