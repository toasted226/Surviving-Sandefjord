using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Item
{
    [SerializeField] private float addedHeat;
    public float AddedHeat() 
    {
        return addedHeat;
    }
}
