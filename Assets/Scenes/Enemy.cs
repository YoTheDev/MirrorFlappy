using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : NetworkBehaviour
{
    [SerializeField] private List<GameObject> player;
    [SyncVar] private int ChoosenPlayer;

    private void Start()
    {
        ChoosenPlayer = Random.Range(0, 1);
        GameObject P1 = GameObject.FindWithTag("Player_01");
        GameObject P2 = GameObject.FindWithTag("Player_02");
        player.Add(P1);
        player.Add(P2);
    }

    void Update()
    {
        Vector3.Lerp(transform.position, player[ChoosenPlayer].transform.position, 10);
    }
}
