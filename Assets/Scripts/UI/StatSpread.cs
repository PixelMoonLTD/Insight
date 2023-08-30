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
        
        text_[5] = "Max Health: " + (stats.max_health + data.newStats.max_health).ToString();
        text_[6] = "Movement Speed: " + (stats.movement_speed * data.newStats.movement_speed).ToString();
        text_[0] = "Fire Rate: " + ((stats.fire_rate * data.newStats.fire_rate) / 16).ToString() + "/1s";
        text_[1] = "Crit Chance: " + (stats.critical_rate + data.newStats.critical_rate).ToString() + "/128";
        text_[2] = "Damage: " + (stats.damage * data.newStats.damage).ToString();
        text_[3] = "Bullet Speed: " + (stats.shoot_speed * data.newStats.shoot_speed).ToString() + "m/s";
        text_[4] = "Elemental Damage: " + (stats.elemental_damage + data.newStats.elemental_damage).ToString();

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

        text[5].text = "Max Health: " + stats.max_health.ToString();

        text[6].text = "Movement Speed: " + stats.movement_speed.ToString();

        text[0].text = "Fire Rate: " + (stats.fire_rate/16).ToString() + "/1s";

        text[1].text = "Crit Chance: " + stats.critical_rate.ToString() + "/128";

        text[2].text = "Damage: " + stats.damage.ToString();

        text[3].text = "Bullet Speed: " + stats.shoot_speed.ToString() + "m/s";

        text[4].text = "Elemental Damage: " + stats.elemental_damage.ToString();
    }
}
