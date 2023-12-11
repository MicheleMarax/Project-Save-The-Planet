using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileHelperUpgrade", menuName = "Upgrade/ProjectileShip")]
public class ProjectileHelperUpgrade : UpgradeBase
{
    [SerializeField] PlayerStats stats;
    [SerializeField] HelpShip ship;

    public override void Apply()
    {
        stats.Ship = Instantiate(ship);
    }

    public override string GetDescription()
    {
        return "Spawn an orbital ship defense";
    }
}



