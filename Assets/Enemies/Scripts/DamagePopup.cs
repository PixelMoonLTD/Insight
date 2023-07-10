using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    [SerializeField] private TMP_Text tmpText;
    private Vector2 _randomSpawnPos;
    
    private void Start()
    {
        _randomSpawnPos = (Vector2)transform.position * Random.Range(0.5f, 1.5f);
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
            case >= 50 and < 75:
                tmpText.color = Color.yellow;
                break;
            case >= 75 and < 90:
                tmpText.color = new Color(1, 0.5f, 0);
                break;
            default:
                tmpText.color = Color.red;
                break;
        }
    }
}
