using UnityEngine;

public class attraction : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            transform.position = Vector2.MoveTowards(transform.position, other.transform.position, 5 * Time.deltaTime);
        }
    }
}
