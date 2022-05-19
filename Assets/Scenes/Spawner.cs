using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Spawner : NetworkBehaviour
{
    [SerializeField] private int currentPlayer;
    public GameObject[] Player;
    public GameObject[] spawner;

    private void Start()
    {
        currentPlayer = 0;
    }
    void Update()
    {
        switch (currentPlayer)
        {
            case 0 :
                Player[0] = GameObject.FindWithTag("Player");
                Player[0].transform.tag = "Player_01";
                Player[0].transform.position = spawner[0].transform.position;
                currentPlayer++;
                break;
            case 1 :
                Player[1] = GameObject.FindWithTag("Player");
                Player[1].transform.tag = "Player_02";
                Player[1].transform.position = spawner[1].transform.position;
                currentPlayer++;
                break;
            case 2 :
                Player[2] = GameObject.FindWithTag("Player");
                Player[2].transform.tag = "Player_03";
                Player[2].transform.position = spawner[2].transform.position;
                currentPlayer++;
                break;
            case 3 :
                Player[3] = GameObject.FindWithTag("Player");
                Player[3].transform.tag = "Player_04";
                Player[3].transform.position = spawner[3].transform.position;
                currentPlayer++;
                break;
            default:
                currentPlayer = 0;
                break;
        }
    }
}
