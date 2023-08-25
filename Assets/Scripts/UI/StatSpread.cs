using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatSpread : MonoBehaviour
{
    [SerializeField]
    Image[] icons = new Image[10];

    [SerializeField]
    TMP_Text[] text = new TMP_Text[10];

    private void Start()
    {
        PlayerStats stats = GameManager.instance.player.GetComponent<Player>().GetStats();

        text[0].text = "Max Health: " + stats.max_health.ToString();
    }
}
