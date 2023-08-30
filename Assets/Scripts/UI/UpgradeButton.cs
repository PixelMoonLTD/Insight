using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UpgradeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{ 
    [SerializeField] Image icon;

    [SerializeField] TMP_Text text;

    [SerializeField] TMP_Text desc;

    UpgradeData data_;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(data_.upgradeType == UpgradeType.STATBUFF)
            GameManager.instance.spread.ShowUpdatedStats(data_);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (data_.upgradeType == UpgradeType.STATBUFF)
            GameManager.instance.spread.HideUpdatedStats();
    }

    public void SetButtonData(UpgradeData data)
    {
        data_ = data;
        icon.sprite = data.icon;
        text.text = data.upgradeName;
        desc.text = data.description;
    }
}
