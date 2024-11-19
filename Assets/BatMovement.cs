using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{
    // Target position to move towards
    public Vector3 targetPosition;

    // Speed of movement
    public float speed = 5f;

    void Update()
    {
        // Move the GameObject towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Optional: Stop moving when the target is reached
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            Debug.Log("Target position reached!");
        }
    }
}
