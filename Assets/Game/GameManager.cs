using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] Slider LevelUp;

    public static GameManager instance;

    UpgradepanelManager upgrade;
    [SerializeField] List<UpgradeData> upgrades;

    float currentSliderSpeed = 0;

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

    public void ResetSlider()
    {
        LevelUp.maxValue = LevelUp.value + 2.5f;
        LevelUp.value = 0;
        upgrade.OpenPanel(GetUpgrades(4));
    }

    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();

        if(count > upgrades.Count)
        {
            count = upgrades.Count;
        }

        for (int i = 0; i < count; i++)
        {
            upgradeList.Add(upgrades[Random.Range(0, upgrades.Count)]);
        }

        return upgradeList;
    }
}
