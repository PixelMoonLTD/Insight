using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParentController : MonoBehaviour
{
    public Vector2 PointerPos { get; set; }

    public GameObject weaponPos;

    [SerializeField]
    private SpriteRenderer Weapon;

    private void Update()
    {
        Vector2 direction = (PointerPos - (Vector2)transform.position).normalized;
        transform.right = direction;

        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -1;
        }
        else if (direction.x > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;

        if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            Weapon.sortingOrder = 4;
        }
        else
        {
            Weapon.sortingOrder = 6;
        }

        //Weapon.transform.right = (PointerPos - (Vector2)Weapon.transform.position).normalized;
    }
}
