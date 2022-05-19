using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.UIElements;

namespace Scenes
{
    public class player : NetworkBehaviour
    {
        [SerializeField] public int speed;
        [SerializeField] public int JumpBoost;
        private Rigidbody rb;
        [SerializeField] private GameObject Projectile;
        [SerializeField] private GameObject Canon;
        private GameObject Camera;

        [Client]
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            Camera = GameObject.Find("Main Camera");
        }
        
        private void Update()
        {
            if(!hasAuthority) { return; }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * (speed * Time.deltaTime));
                Quaternion rotation = Quaternion.LookRotation(Vector3.forward);
                transform.rotation = rotation;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Translate(Vector3.left * (speed * Time.deltaTime));
                //Quaternion rotation = Quaternion.LookRotation(Vector3.back);
                //transform.rotation = rotation;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * JumpBoost, ForceMode.Impulse);
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Instantiate(Projectile,Canon.transform.position,Canon.transform.rotation);
            }
            Camera.transform.position = transform.TransformPoint(0, 2, -25);
        }

        public void Death()
        {
            Destroy(gameObject);
        }
    }
}
