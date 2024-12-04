using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class movementNPC : MonoBehaviour
{
    public GameObject Player;
    public bool spawnFromLeft;
    private Rigidbody rb;
    public float speed;


    void Start()
    {
        Player = GameObject.Find("Player Minifig"); 
        rb = GetComponent<Rigidbody>();
        if (spawnFromLeft)
        {
            rb.MoveRotation(Quaternion.Euler(-transform.right));
        }
        else
        {
            rb.MoveRotation(Quaternion.Euler(transform.right));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(Player.transform);
        if (spawnFromLeft)
        {
          //  gameObject.transform.eulerAngles = -Vector3.right;
            rb.velocity = transform.forward * speed;
            Debug.Log("spawnFromLeft code is running");
        }
        else
        {
          //  gameObject.transform.eulerAngles = Vector3.right;
            rb.velocity = transform.forward * speed;
        }
    }
}
