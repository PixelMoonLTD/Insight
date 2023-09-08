using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;


public class UpgradeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{ 
    [SerializeField] Image icon;

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
        GetComponent<TooltipTrigger>().header = data.upgradeName + "\n" + data.tier.ToString() + "\n" + "------------------------";
        GetComponent<TooltipTrigger>().content = data.description;
    }
}
