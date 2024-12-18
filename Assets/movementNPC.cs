using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using UnityEngine;

public class movementNPC : MonoBehaviour
{
    public GameObject Player;
    public bool spawnFromLeft;
    private Rigidbody rb;
    public float speed;
    private bool NPChasStopped;
    private Animator anim;
    public float delayedFall;
    public bool hasBeenCounted;
    void Start()
    {
        Player = GameObject.Find("Player Minifig"); 
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
      private void OnTriggerEnter(Collider other)
      {
          if(other.gameObject.tag == "NPCstopper")
          {
              
              anim.SetTrigger("Fall");
              StartCoroutine(delayedStop());
              
          }
      }
      private IEnumerator delayedStop()
      {
          yield return new WaitForSeconds(delayedFall);
          NPChasStopped = true;
          rb.velocity = transform.forward * 1.0f;
          StopAllCoroutines(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("NPC has touched the player");
        }
    }
    void Update()
    {
        if (!NPChasStopped)
        {
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
        else
        {
            rb.velocity = transform.forward * 0.0f;
        }
    }
}
