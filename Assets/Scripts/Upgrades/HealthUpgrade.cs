using UnityEngine;

[CreateAssetMenu(fileName = "HealthUpgrade", menuName = "Upgrade/Health")]
public class HealthUpgrade : UpgradeBase
{
    [SerializeField] PlayerStats stats;
    [SerializeField] float[] healthMultiplier;

    public override void Apply()
    {
        stats.HealthMultiplier = healthMultiplier[CurrentGameLevel];
        CurrentGameLevel++;
    }

    public override string GetDescription()
    {
        return description + "\n-Max health +" + healthMultiplier[CurrentGameLevel].ToString() + "%";
    }

    private void OnEnable()
    {
        maxLevel = healthMultiplier.Length;
    }
}