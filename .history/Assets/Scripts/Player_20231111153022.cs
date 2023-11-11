using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float cold;
    [SerializeField] private float coldResistance;
    [SerializeField] private float warmupRate;
    [SerializeField] private float freezingThreshold;
    [SerializeField] private float maxCold;

    [SerializeField] private Campfire campfire;

    private float distanceToHeat;
    
    void Update()
    {
        if (campfire != null)
        {
            Vector2 campfirePos = campfire.transform.position;
            Vector2 pos = transform.position;
            distanceToHeat = Mathf.Sqrt(Mathf.Pow(campfirePos.y - pos.y, 2) + Mathf.Pow(campfirePos.x - pos.x, 2));
        }

        if (cold > freezingThreshold)
        {
            // Let the light fade
        }
        if (cold >= maxCold)
        {
            // You're going to die now, dear boy
        }

        if (distanceToHeat > campfire.HeatRange() && cold < maxCold || !campfire.Burning() && cold < maxCold)
            cold += Time.deltaTime * (1 - coldResistance);
        else if (distanceToHeat <= campfire.HeatRange() && campfire.Burning() && cold >= 0)
            cold -= Time.deltaTime * warmupRate;
    }
}
