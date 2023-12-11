using UnityEngine;
using UnityEngine.UI;

public class UpgradeSlotUI : MonoBehaviour
{
    public Sprite backSpriteDisable;
    public Sprite backSpriteEnable;

    public Image forwardImage;
    public Image backImage;

    private UpgradeBase skill;

    public UpgradeBase Skill { get => skill;}

    void Start()
    {
        forwardImage.enabled = false;
        backImage.sprite = backSpriteDisable;
        skill = null;
    }

    public void SetSkill(UpgradeBase skill)
    {
        forwardImage.enabled = true;
        forwardImage.sprite = skill.upgradeSprite;
        backImage.sprite = backSpriteEnable;
        this.skill = skill;
    }

    public void Clear()
    {
        Start();
        
    }
}
