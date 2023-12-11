using UnityEngine;
using System.Collections.Generic;

public class UpgradeDisplay : MonoBehaviour
{
    public UpgradeSlotUI slotPrefab;
    public GameObject parentContainer;

    List<UpgradeSlotUI> slot;

    public void CreateDisplay(int slotCount)
    {
        slot = new List<UpgradeSlotUI>(slotCount);

        for (int i = 0; i < slotCount; i++)
        {
            slot.Add(Instantiate(slotPrefab, parentContainer.transform));
        }    
    }

    public void Replace(UpgradeBase upgradeToReplace)
    {
        //Cerco se contiene gia
        for (int i = 0; i < slot.Count; i++)
        {
            if(slot[i].Skill == upgradeToReplace)
            {
                slot[i].SetSkill(upgradeToReplace);
                return;
            }
        }

        //Cerco primo libero
        foreach (var item in slot)
        {
            if (item.Skill == null)
            {
                item.SetSkill(upgradeToReplace);
                return;
            }
                
        }
       
    }

    public void Clear()
    {
        foreach (var item in slot)
        {
            item.Clear();
        }
    }
}

