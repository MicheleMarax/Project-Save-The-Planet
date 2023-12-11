using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class RewardPanel : MonoBehaviour
{
    [SerializeField] Image leftUpgradeImg;
    [SerializeField] Image rightUpgradeImg;

    [SerializeField] TextMeshProUGUI skillName1;
    [SerializeField] TextMeshProUGUI skillName2;

    [SerializeField] TextMeshProUGUI description1;
    [SerializeField] TextMeshProUGUI description2;

    [SerializeField] Button leftUpgradeBtn;
    [SerializeField] Button rightUpgradeBtn;

    Action<UpgradeBase> toCall;
    UpgradeBase[] upgrade;

    private void Start()
    {
        leftUpgradeBtn.onClick.AddListener(LeftBtnClick);
        rightUpgradeBtn.onClick.AddListener(RightBtnClick);
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void Init(UpgradeBase[] upgrade, Action<UpgradeBase> callback)
    {
        toCall = callback;

        if(upgrade[0] != null)
        {
            leftUpgradeBtn.gameObject.SetActive(true);
            leftUpgradeImg.sprite = upgrade[0].upgradeSprite;
            skillName1.text = upgrade[0].SkillName;
            description1.text = upgrade[0].GetDescription();
        }
        else
        {
            leftUpgradeBtn.gameObject.SetActive(false);
        }

        if(upgrade[1] != null)
        {
            rightUpgradeBtn.gameObject.SetActive(true);
            rightUpgradeImg.sprite = upgrade[1].upgradeSprite;
            skillName2.text = upgrade[1].SkillName;
            description2.text = upgrade[1].GetDescription();
        }
        else
        {
            rightUpgradeBtn.gameObject.SetActive(false);
        }

        this.upgrade = upgrade;
    }

    private void LeftBtnClick()
    {
        toCall?.Invoke(upgrade[0]);
        gameObject.SetActive(false);
    }

    private void RightBtnClick()
    {
        toCall?.Invoke(upgrade[1]);
        gameObject.SetActive(false);
    }
}