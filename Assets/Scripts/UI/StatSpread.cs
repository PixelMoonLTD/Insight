using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatSpread : MonoBehaviour
{
    [SerializeField]
    Image[] icons = new Image[10];

    [SerializeField]
    TMP_Text[] text = new TMP_Text[10];

    PlayerStats stats;

    private void Start()
    {
        stats = GameManager.instance.player.GetComponent<Player>().GetStats();
        DisplayStats();
    }

    private void OnEnable()
    {
        DisplayStats();
    }

    //get which stat will be changed based on upgrade data from button hovered over.
    public void ShowUpdatedStats(UpgradeData data)
    {
        string[] text_ = new string[10];
        
        text_[0] = "Max Health: " + (stats.max_health + data.newStats.max_health).ToString();
        text_[1] = "Movement Speed: " + (stats.movement_speed * data.newStats.movement_speed).ToString();
        text_[2] = "Fire Rate: " + ((stats.fire_rate * data.newStats.fire_rate) / 16).ToString() + "/1s";
        text_[3] = "Crit Chance: " + (stats.critical_rate + data.newStats.critical_rate).ToString() + "/128";

        for (int i = 0; i < text_.Length - 1; i++)
        {
            if(text_[i] != text[i].text)
            {
                text[i].text = text_[i];
                text[i].color = new Color(0,255,0,0.85f);
            }
        }
    }

    public void HideUpdatedStats()
    {
        DisplayStats();
        for (int i = 0; i < text.Length - 1; i++)
        {
            text[i].color = new Color(255, 255, 255, 1);
        }
    }

    public void DisplayStats()
    { 

        text[0].text = "Max Health: " + stats.max_health.ToString();

        text[1].text = "Movement Speed: " + stats.movement_speed.ToString();

        text[2].text = "Fire Rate: " + (stats.fire_rate/16).ToString() + "/1s";

        text[3].text = "Crit Chance: " + stats.critical_rate.ToString() + "/128";
    }
}
