using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] Slider LevelUp;

    public static GameManager instance;

    UpgradepanelManager upgrade;
    [SerializeField] List<UpgradeData> allUpgrades;

    List<UpgradeData> availableUpgrades;
    List<UpgradeData> acquiredUpgrades;

    //float currentSliderSpeed = 0;

    void Start()
    {
        if(instance != null)
        {
            Destroy(instance);
            
        }

        instance = this;

        upgrade = GetComponent<UpgradepanelManager>();

        LevelUp.value = 0;

        Cursor.lockState = CursorLockMode.Confined;
    }

    public void UpdateSlider(float value)
    {
        LevelUp.value += value;

        if (LevelUp.value >= LevelUp.maxValue)
        {
            ResetSlider();
        }
    }

    public void Upgrade(int selectedUpgradeID)
    {
        UpgradeData upgradeData = availableUpgrades[selectedUpgradeID];

        if(acquiredUpgrades == null) { acquiredUpgrades = new List<UpgradeData>(); }
        
        //change out for the inventory system vlad will implement I think?
        //also need to move upgrade stuff off game manager and onto player
        acquiredUpgrades.Add(upgradeData);

        if (upgradeData.upgradeType == UpgradeType.BULLETCHANGE)
        {
            
            allUpgrades.RemoveAll(item => item.upgradeType == UpgradeType.BULLETCHANGE);
        }

        if (!upgradeData.stackable)
        {
            allUpgrades.Remove(upgradeData);
        }

    }



    public void ResetSlider()
    {
        LevelUp.maxValue = LevelUp.value + 2.5f;
        LevelUp.value = 0;

        if(availableUpgrades == null) { availableUpgrades = new List<UpgradeData>(); }
        availableUpgrades.Clear();
        availableUpgrades.AddRange(GetUpgrades(4));

        upgrade.OpenPanel(availableUpgrades);
    }

    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();

        if(count > allUpgrades.Count)
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
