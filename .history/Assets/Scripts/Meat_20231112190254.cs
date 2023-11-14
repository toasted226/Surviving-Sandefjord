using UnityEngine;

public class Meat : Item
{
    [SerializeField] private bool isCooked;
    [SerializeField] private float hungerReduction;
    public override void UseItem(PlayerController caller)
    {
        if (isCooked) 
        {
            base.UseItem(caller);
            caller.GetComponent<Player>().Eat(hungerReduction);
            caller.ConsumeItem();
        }
    }
}
