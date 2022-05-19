using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Scenes;
using UnityEngine;

public class Projectile : NetworkBehaviour
{
    [SerializeField] private int Speed;
    private void Update()
    {
        transform.Translate(Vector3.right * (Speed * Time.deltaTime));
    }
    
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<player>().Death();
            Debug.Log("hello");
        }
    }
}
