using UnityEngine;

[CreateAssetMenu(fileName = "RateoUpgrade", menuName = "Upgrade/Rateo")]
public class RateoUpgrade : UpgradeBase
{
    [SerializeField] PlayerStats stats;
    [SerializeField] float[] rateoMultiplier;

    public override void Apply()
    {
        stats.RateoMultiplier = rateoMultiplier[CurrentGameLevel];
        CurrentGameLevel++;
    }

    public override string GetDescription()
    {
        return description + "\n-Rateo+" + rateoMultiplier[CurrentGameLevel].ToString() + "%";
    }

    private void OnEnable()
    {
        maxLevel = rateoMultiplier.Length - 1;
    }
}





