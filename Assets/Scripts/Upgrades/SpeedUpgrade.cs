using UnityEngine;

[CreateAssetMenu(fileName = "SpeedUpgrade", menuName = "Upgrade/Speed")]
public class SpeedUpgrade : UpgradeBase
{
    [SerializeField] PlayerStats stats;
    [SerializeField] float[] speedMultiplier;

    public override void Apply()
    {
        stats.PlayerSpeedMultiplier = speedMultiplier[CurrentGameLevel];
        CurrentGameLevel++;
    }

    public override string GetDescription()
    {
        return description + "\n-Speed+" + speedMultiplier[CurrentGameLevel].ToString() + "%";
    }

    private void OnEnable()
    {
        maxLevel = speedMultiplier.Length;
    }
}



