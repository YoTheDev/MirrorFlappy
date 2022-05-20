using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : NetworkBehaviour
{
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private GameObject[] spawner;
    [SerializeField] private int valueUpdated;
    [SerializeField] private int seconds;
    private int currentEnemy;
    private int currentSpawner;
    private float time;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        valueUpdated = 0;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        time += Time.deltaTime;
        seconds = Convert.ToInt32(time % 60);
        if (seconds == valueUpdated)
        {
            Switch();
            valueUpdated++;
        }
    }

    [Command]
    void Switch()
    {
        switch (seconds)
        {
            case 3 :
                int randomSpawner = Random.Range(0, 4);
                GameObject enemyGo = Instantiate(enemy[0],spawner[randomSpawner].transform.position,spawner[randomSpawner].transform.rotation);
                NetworkServer.Spawn(enemyGo);
                break;
        }
    }
}
