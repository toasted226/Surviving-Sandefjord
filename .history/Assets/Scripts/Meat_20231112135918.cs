using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : Item
{
    [SerializeField] private bool isCooked;
    [SerializeField] private float hungerReduction;
    public override void UseItem()
    {
        if (isCooked) 
        {
            base.UseItem();
            
        }
    }
}
