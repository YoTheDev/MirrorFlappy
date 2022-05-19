using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : NetworkBehaviour
{
    [SyncVar] private float timer = 60f;
    [SyncVar] private int seconds;
    private int invertSeconds;
    private bool playerConnected;
    public Text timeleft;
    public Text BegginingTypo;
    public Text[] Wave;

    private void Start()
    {
        for (int i = 0; i < Wave.Length; i++)
        {
            Wave[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        seconds = (int) timer % 60;
        timeleft.text = seconds.ToString();
        if (seconds == 0)
        {
            timeleft.gameObject.SetActive(false);
            BegginingTypo.gameObject.SetActive(false);
            Wave[0].gameObject.SetActive(true);
        }
    }
}
