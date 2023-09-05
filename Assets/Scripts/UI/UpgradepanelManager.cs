using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradepanelManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    PauseManager pause;

    [SerializeField] List<UpgradeButton> buttons;


    private void Awake()
    {
        pause = GetComponent<PauseManager>();
    }

    public void OpenPanel(List<UpgradeData> upgradeDatas)
    {

        for (int i = 0; i < upgradeDatas.Count; i++)
        {
            buttons[i].SetButtonData(upgradeDatas[i]);
        }       
        
        pause.PauseGame();
        panel.SetActive(true);
    }

    public void SelectUprade(int pressedButtonID)
    {
        //apply upgrade
        GameManager.instance.player.GetComponent<LevelUp>().Upgrade(pressedButtonID);

        ClosePanel();
    }    

    public void ClosePanel()
    {
        pause.UnpauseGame();
        panel.SetActive(false);
    }
}
