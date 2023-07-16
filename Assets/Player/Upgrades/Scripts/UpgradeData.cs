using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum UpgradeType
{
    STATBUFF,
    WEAPONUNLOCK,
    POWERUNLOCK,
    POWERBUFF,
    WEAPONBUFF
}

[CreateAssetMenu(menuName = "Custom/Upgrades/Upgrade Data", fileName = "NewUpgrade")]
public class UpgradeData : ScriptableObject
{
    [Header("Upgrade Type")]
    public UpgradeType upgrade;
    [Header("Upgrade Attributes")]
    public string upgradeName;
    public Sprite icon;

}
