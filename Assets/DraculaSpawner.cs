using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraculaSpawner : MonoBehaviour
{
    //Variables

    public GameObject DraculaPrefab;
    public GameObject DraculaSpawnerLeft;
    public GameObject DraculaSpawnerRight;
    public float timerInterval;
    private float timer;

    private int directionDecider;
    public int amountToSpawn;
    private bool timerHasBeenActivated = true;
    
    void Start()
    {
        
    }

    IEnumerator spawnNpcs()
    {
        for (int i = 0; i <= amountToSpawn; ++i)
        {
            yield return new WaitForSeconds(3);
            directionDecider = i;
            if (directionDecider % 2 == 0)
            {
                GameObject NPC = Instantiate(DraculaPrefab, DraculaSpawnerRight.transform.position, Quaternion.identity);
                NPC.GetComponent<movementNPC>().spawnFromLeft = false;
            }
            else
            {
                GameObject NPC = Instantiate(DraculaPrefab, DraculaSpawnerLeft.transform.position, Quaternion.identity);
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
