using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private bool requiresItem;

    public virtual void Interact(PlayerController caller) 
    {}

    public void SetRequiresItem(bool requires) 
    {
        requiresItem = requires;
    }

    public bool RequiresItem() 
    {
        
    }
}
