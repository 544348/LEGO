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
    private bool NPChasStopped;
    private Animator anim;

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
        yield return new WaitForSeconds(1);
        NPChasStopped = true;
        rb.velocity = Vector3.zero;

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
       
    }
}
