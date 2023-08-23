using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] Image icon;

    [SerializeField] TMP_Text text;

    [SerializeField] TMP_Text desc;
    public void SetButtonData(UpgradeData data)
    {
        icon.sprite = data.icon;
        text.text = data.name;
        desc.text = data.description;
    }
}
