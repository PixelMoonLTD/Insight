using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    [SerializeField] private TMP_Text tmpText;
    private Vector2 _randomSpawnPos;
    
    private void Start()
    {
        _randomSpawnPos = (Vector2)transform.position * Random.Range(0.89f, 1.11f);
        transform.position = _randomSpawnPos;
        Destroy(gameObject, 1f);
    }

    private void Update()
    {
        tmpText.color = new Color(tmpText.color.r, tmpText.color.g, tmpText.color.b, tmpText.color.a - 0.003f);
        transform.position = Vector2.Lerp(transform.position, (Vector2)transform.position+Vector2.up, 1.0f * Time.deltaTime);
    }

    public void SetDamageText(int amount)
    {
        tmpText.text = amount.ToString();

        switch (amount)
        {
            case >= 10 and < 26:
                tmpText.color = Color.yellow;
                break;
            case >= 26 and < 40:
                tmpText.color = new Color(1, 0.7f, 0.12f);
                break;
            case >= 40 and < 64:
                tmpText.color = new Color(1, 0.4f, 0.07f);
                break;
            case >= 64 and < 82:
                tmpText.color = new Color(1, 0.1f, 0);
                break;
            default:
                tmpText.color = Color.red;
                break;
        }
    }

    public void CriticalPopUp()
    {
        tmpText.text = "CRITICAL";
        tmpText.color = Color.red;
    }
}
