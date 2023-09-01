using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum UpgradeType
{
    STATBUFF,
    FIREPATTERN,
    POWERUNLOCK,
    POWERBUFF,
    WEAPONBUFF,
    BULLETCHANGE
}

public enum UpgradeTier
{
    COMMON = 0,
    RARE = 1,
    LEGENDARY = 2
}

[CreateAssetMenu(menuName = "Custom/Upgrades/Upgrade Data", fileName = "NewUpgrade")]
public class UpgradeData : ScriptableObject
{
    [Header("Upgrade Type")]
    public UpgradeType upgradeType;
    public UpgradeTier tier;
    public bool permanent;
    [Header("Upgrade Attributes")]
    public string upgradeName;
    [TextAreaAttribute]
    public string description;
    public Sprite icon;
    public bool stackable;

    [Header("Upgrade Details")]
    public GameObject BulletObj;
    public PlayerStats newStats;

    [Header("Dependant Upgrades")]
    public List<UpgradeData> upgradeDependacies;

}
