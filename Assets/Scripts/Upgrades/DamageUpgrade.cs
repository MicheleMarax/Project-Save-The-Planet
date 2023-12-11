using UnityEngine;

[CreateAssetMenu(fileName = "DamageUpgrade", menuName = "Upgrade/Damage")]
public class DamageUpgrade : UpgradeBase
{
    [SerializeField] PlayerStats stats;
    [SerializeField] float[] damageMultiplier;

    public override void Apply()
    {
        stats.DamageMultiplier = damageMultiplier[CurrentGameLevel];
        CurrentGameLevel++;
    }

    public override string GetDescription()
    {
        return description + "\n-Damage +" + damageMultiplier[CurrentGameLevel].ToString()+"%";
    }

    private void OnEnable()
    {
        maxLevel = damageMultiplier.Length;
    }
}





