using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;

    //float currentSliderSpeed = 0;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(instance);
            
        }

        instance = this;

        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player");
    }
}
