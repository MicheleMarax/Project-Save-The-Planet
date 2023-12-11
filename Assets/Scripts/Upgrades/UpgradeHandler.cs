using UnityEngine;
using System.Collections.Generic;

public class UpgradeHandler : Singleton<UpgradeHandler>
{
    private int currentLevel = 1;
    private int xp = 0;
    public PlayerStats stats;
    public UpgradeDisplay display;

    [Header("Level")]
    [SerializeField] int[] xpRequiredForLevel;
    [SerializeField] TextSlider slider;
    [SerializeField] RewardPanel rewardPanel;

    [Header("Upgrades")]
    [SerializeField] int upgradeSlots = 5;
    [SerializeField] List<UpgradeBase> upgradeInUse;
    [SerializeField] List<UpgradeBase> allUpgrades;

    private void Start()
    {
        GameManager.instance.OnGameStart += ResetLevel;
        rewardPanel.gameObject.SetActive(false);
        display.CreateDisplay(upgradeSlots);
    }

    #region XP LEVELLING

    private void ResetLevel()
    {
        currentLevel = 1;
        xp = 0;
        slider.UpgradeSlider(xp, xpRequiredForLevel[currentLevel]);
        slider.SetText(currentLevel.ToString());

        foreach (var item in upgradeInUse)
        {
            item.CurrentGameLevel = 0;
        }

        upgradeInUse.Clear();
        display.Clear();
        stats.ResetStats();
    }

    public void AddXp(int exp)
    {
        this.xp += exp;

        //Passaggio di livello
        if (currentLevel < xpRequiredForLevel.Length - 1 && xp >= xpRequiredForLevel[currentLevel])
        {
            xp -= xpRequiredForLevel[currentLevel];
            currentLevel++;
            rewardPanel.gameObject.SetActive(true);
            rewardPanel.Init(GetAvailableUpgrade(), AddUpgrade);
        }

        slider.UpgradeSlider(xp, xpRequiredForLevel[currentLevel]);
        slider.SetText(currentLevel.ToString());
    }
    #endregion

    #region UPGARDE HANDLING
    private UpgradeBase[] GetAvailableUpgrade()
    {
        UpgradeBase[] toReturn = new UpgradeBase[2];
        List<UpgradeBase> upgradesAvailable = new List<UpgradeBase>(allUpgrades);

        //Remove max upgrade
        foreach (var item in upgradeInUse)
        {
            if (item.isGameMaxed())
                upgradesAvailable.Remove(item);
        }

        //Remove exlude
        foreach (var inUse in upgradeInUse)
        {
            foreach (var item in inUse.UpgradeToExclude)
            {
                upgradesAvailable.Remove(item);
            }
        }



        for (int i = 0; i < 2; i++)
        {
            if (upgradesAvailable.Count <= 0)
                break;

            int index = Random.Range(0, upgradesAvailable.Count);
            toReturn[i] = upgradesAvailable[index];
            upgradesAvailable.RemoveAt(index);
        }

        return toReturn;
    }

    private void AddUpgrade(UpgradeBase upgrade)
    {
        if (!upgradeInUse.Contains(upgrade))
        {
            upgradeInUse.Add(upgrade);
        }

        upgrade.Apply();
        display.Replace(upgrade);
    } 
    #endregion
}
