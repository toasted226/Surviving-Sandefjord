using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float cold;
    [SerializeField] private float coldResistance;
    [SerializeField] private float warmupRate;
    [SerializeField] private float warningThreshold;
    [SerializeField] private float freezingThreshold;
    [SerializeField] private float maxCold;

    [SerializeField] private Campfire campfire;
    [SerializeField] private Image coldVignette;
    [SerializeField] private Image deathPanel;

    private float distanceToHeat;
    private float coldVignetteAlpha;
    private float deathPanelAlpha;

    void Start()
    {
        coldVignetteAlpha = 0f;
    }
    
    void Update()
    {
        if (campfire != null)
        {
            Vector2 campfirePos = campfire.transform.position;
            Vector2 pos = transform.position;
            distanceToHeat = Mathf.Sqrt(Mathf.Pow(campfirePos.y - pos.y, 2) + Mathf.Pow(campfirePos.x - pos.x, 2));
        }

        if (cold > warningThreshold) 
        {
            // You're starting to cold
            coldVignetteAlpha = (cold - warningThreshold) / (maxCold - warningThreshold);
        }
        else
        {
            coldVignetteAlpha = 0f;
        }
        
        if (cold > freezingThreshold)
        {
            // Let the light fade
        }
        else 
        {

        }

        if (cold >= maxCold)
        {
            // You're going to die now, dear boy
        }

        Color vignette = coldVignette.color;
        Color death = deathPanel.color;
        coldVignette.color = new Color(vignette.r, vignette.g, vignette.b, coldVignetteAlpha);
        deathPanel.color = new Color(death.r, death.g, death.b, deathPanelAlpha);

        if (distanceToHeat > campfire.HeatRange() && cold < maxCold || !campfire.Burning() && cold < maxCold)
            cold += Time.deltaTime * (1 - coldResistance);
        else if (distanceToHeat <= campfire.HeatRange() && campfire.Burning() && cold >= 0)
            cold -= Time.deltaTime * warmupRate;
    }
}
