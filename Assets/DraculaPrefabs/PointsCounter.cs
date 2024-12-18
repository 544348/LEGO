using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsCounter : MonoBehaviour
{

    public TextMeshProUGUI counter;
    private int points;
    
    // Start is called before the first frame update
    void Start()
    {
        counter.text = "Points";
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            Debug.Log("player has collided with " + collision.gameObject.tag); 
            {
                collision.gameObject.GetComponent<movementNPC>().hasBeenCounted = true;
                points++;
                counter.text = "points " + points.ToString();
            }
        }
    }
}
