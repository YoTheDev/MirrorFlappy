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
        [SerializeField] private GameObject BigProjectile;
        [SerializeField] private GameObject Canon;
        [SerializeField] public int ALED;
        [SerializeField] private GameObject FirstCase;
        [SerializeField] private GameObject SecondCase;
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
            var position = transform.position;
            position = new Vector3(Mathf.Clamp(position.x, -28, 37.75f), Mathf.Clamp(position.y, -24.5f, 12.5f), position.z);
            transform.position = position;
            if (transform.position.x <= -28 || transform.position.x >= 37.75 || transform.position.y <= -24.5 || transform.position.y >= 12.5)
            {
                Death();
            }
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
                switch (ALED)
                {
                    case 0:
                        Fire();
                        break;
                    case 1:
                        BigFire();
                        break;
                }
            }
            Camera.transform.position = transform.TransformPoint(0, 2, -25);
        }
        [Command]
        void Fire()
        {
            GameObject bulletClone = Instantiate(Projectile,Canon.transform.position,Canon.transform.rotation);
            NetworkServer.Spawn(bulletClone);
        }
        [Command]
        void BigFire()
        {
            GameObject BigbulletClone = Instantiate(BigProjectile,Canon.transform.position,Canon.transform.rotation);
        }
        public void Death()
        {
            Destroy(gameObject);
        }
    }
}
