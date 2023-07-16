using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] Image icon;

    [SerializeField] TMP_Text text;

    public void SetIcon(UpgradeData data)
    {
        icon.sprite = data.icon;
    }

    public void SetText(UpgradeData data)
    {
        text.text = data.name;
    }
}
