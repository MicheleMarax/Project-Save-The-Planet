using UnityEngine;
using System.Collections.Generic;

public abstract class UpgradeBase : ScriptableObject
{
    public Sprite upgradeSprite;
    public string description;

    [SerializeField]private string skillName;
    [SerializeField] List<UpgradeBase> upgradeToExclude;

    protected int maxLevel;
    private int inGameLevel = 0;

    #region PROPERTY
    public int MaxLevel { get => maxLevel; private set => maxLevel = value; }
    public int CurrentGameLevel
    {
        get => inGameLevel;
        set
        {
            if (value > maxLevel)
                inGameLevel = maxLevel;
            else if (value < 0)
                inGameLevel = 0;
            else
                inGameLevel = value;
        }
    }
    public List<UpgradeBase> UpgradeToExclude { get => upgradeToExclude; private set => upgradeToExclude = value; }
    public string SkillName
    {
        get
        {
            if (inGameLevel == 0)
                return skillName;
            else
                return skillName + " " + inGameLevel;
        }
        private set => skillName = value;
    }

    #endregion

    public abstract void Apply();

    //public int Update()
    //{
    //    CurrentLevel++;
    //    return CurrentLevel;
    //}

    private void OnDisable()
    {
        
        inGameLevel = 0;
    }

    public bool isGameMaxed()
    {
        return inGameLevel >= maxLevel;
    }

    public abstract string GetDescription();
}



