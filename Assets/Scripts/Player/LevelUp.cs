using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{
    [SerializeField] Slider LevelUpSlider;

    UpgradepanelManager upgradePanel;
    [SerializeField] List<UpgradeData> allUpgrades;

    List<UpgradeData> availableUpgrades;
    List<UpgradeData> acquiredUpgrades;
    // Start is called before the first frame update
    void Start()
    {
        upgradePanel = GameManager.instance.GetComponent<UpgradepanelManager>();

        LevelUpSlider.value = 0;

        Cursor.lockState = CursorLockMode.Confined;
    }

    public void UpdateSlider(float value)
    {
        LevelUpSlider.value += value;

        if (LevelUpSlider.value >= LevelUpSlider.maxValue)
        {
            ResetSlider();
        }
    }

    public void Upgrade(int selectedUpgradeID)
    {
        UpgradeData upgradeData = availableUpgrades[selectedUpgradeID];

        if (acquiredUpgrades == null) { acquiredUpgrades = new List<UpgradeData>(); }

        acquiredUpgrades.Add(upgradeData);
        
        switch (upgradeData.upgradeType)
        {
            case UpgradeType.STATBUFF:
                gameObject.GetComponent<Player>().IncreasePlayerStat(upgradeData.newStats);
                break;
            case UpgradeType.FIREPATTERN:
                break;
            case UpgradeType.POWERUNLOCK:
                break;
            case UpgradeType.POWERBUFF:
                break;
            case UpgradeType.WEAPONBUFF:
                break;
            case UpgradeType.BULLETCHANGE:
                GetComponent<Player>().ChangeBulletType(upgradeData.BulletObj);
                allUpgrades.RemoveAll(item => item.upgradeType == UpgradeType.BULLETCHANGE);
                break;
        }

        //change out for the inventory system vlad will implement I think?
        //also need to move upgrade stuff off game manager and onto player
        

        if (!upgradeData.stackable)
        {
            allUpgrades.Remove(upgradeData);
        }

    }



    public void ResetSlider()
    {
        LevelUpSlider.maxValue = LevelUpSlider.value + 0.25f;
        LevelUpSlider.value = 0;

        if (availableUpgrades == null) { availableUpgrades = new List<UpgradeData>(); }
        availableUpgrades.Clear();
        availableUpgrades.AddRange(GetUpgrades(4));

        upgradePanel.OpenPanel(availableUpgrades);
    }

    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();

        if (count > allUpgrades.Count)
        {
            count = allUpgrades.Count;
        }

        for (int i = 0; i < count; i++)
        {
            upgradeList.Add(allUpgrades[Random.Range(0, allUpgrades.Count)]);
        }

        return upgradeList;
    }
}
