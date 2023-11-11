using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WoodSource : Interactable
{
    public int health = 5;
    public GameObject woodPrefab;

    void Start()
    {
        
    }

    public override void Interact(PlayerController caller)
    {
        base.Interact(caller);

        if (health > 1) 
        {
            health--;
            Animate();
        } 
        else
        {
            health = 0;
            Die();
        }
    }

    void Animate() 
    {
        Debug.Log($"The tree has been chopped! {health} health points remaining.");
    }

    void Die() 
    {
        Instantiate(woodPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
