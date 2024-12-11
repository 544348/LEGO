using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraculaSpawner : MonoBehaviour
{
    //Variables

    public GameObject[] DraculaPrefableft;
    public GameObject[] DraculaPrefabright;
    public GameObject DraculaSpawnerLeft;
    public GameObject DraculaSpawnerRight;
    public float timerInterval;
    private float timer;

    private int spawnoffset = 0;
    private int directionDecider;
    public int amountToSpawn;
    private bool timerHasBeenActivated = true;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    IEnumerator spawnNpcs()
    {
        for (int i = 0; i <= amountToSpawn; ++i)
        {
            yield return new WaitForSeconds(3);
            spawnoffset++;
            directionDecider = i;
            if (directionDecider % 2 == 0)
            {
                GameObject NPC = Instantiate(DraculaPrefableft[Random.Range(0, DraculaPrefableft.Length)], DraculaSpawnerRight.transform.position + new Vector3(0 ,0 ,spawnoffset), DraculaSpawnerRight.transform.rotation);
                NPC.GetComponent<movementNPC>().spawnFromLeft = false;

            }
            else
            {
                GameObject NPC = Instantiate(DraculaPrefabright[Random.Range(0, DraculaPrefabright.Length)], DraculaSpawnerLeft.transform.position + new Vector3(0, 0, spawnoffset), DraculaSpawnerLeft.transform.rotation);
                NPC.GetComponent<movementNPC>().spawnFromLeft = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(timerHasBeenActivated)
        {
            timer += Time.deltaTime;
            if(timer >= timerInterval)
            {
                StartCoroutine(spawnNpcs());
              timerHasBeenActivated = false;
            }
        }
    }
}
