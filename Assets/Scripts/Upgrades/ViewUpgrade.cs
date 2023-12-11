using UnityEngine;

[CreateAssetMenu(fileName = "ViewUpgrade", menuName = "Upgrade/View")]
public class ViewUpgrade : UpgradeBase
{
    [SerializeField] PlayerStats stats;
    [SerializeField] float[] viewMultiplier;

    public override void Apply()
    {
        stats.CamSizeMultiplier = viewMultiplier[CurrentGameLevel];
        CurrentGameLevel++;
    }

    public override string GetDescription()
    {
        return description + "\n-View+" + viewMultiplier[CurrentGameLevel].ToString() + "%";
    }

    private void OnEnable()
    {
        maxLevel = viewMultiplier.Length;
    }
}



