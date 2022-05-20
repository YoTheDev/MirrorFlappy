using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : NetworkBehaviour
{
    [SerializeField] private GameObject[] player;
    [SyncVar] private int ChoosenPlayer;

    private void Start()
    {
        ChoosenPlayer = Random.Range(0, 1);
    }

    void Update()
    {
        if(player[0] == null)
        {
            player[0] = GameObject.FindWithTag("Player_01");
        }
        if(player[1] == null)
        {
            player[1] = GameObject.FindWithTag("Player_01");
        }
        if (player[ChoosenPlayer] != null)
        {
            transform.position = Vector3.Lerp(transform.position,player[ChoosenPlayer].transform.position,0.5f * Time.deltaTime);
        }
    }
}
