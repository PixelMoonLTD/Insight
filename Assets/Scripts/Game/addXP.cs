using UnityEngine;

public class addXP : MonoBehaviour
{
    Vector2 _randomSpawnPos;

    float XP;
    // Start is called before the first frame update
    void Start()
    {
        _randomSpawnPos = (Vector2)transform.position * Random.Range(0.89f, 1.11f);
        transform.position = _randomSpawnPos;
    }

    public void SetXP(float _xp)
    {
        XP = _xp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<LevelUp>().UpdateSlider(XP/100);
            Destroy(gameObject);
        }
    }
}
