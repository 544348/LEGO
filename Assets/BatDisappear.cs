using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BatDisappear : MonoBehaviour
{
    [Tooltip("Time in seconds before the GameObject is disabled.")]
    public float timeBeforeDisable = 5f;

    private float countdown;

    void Start()
    {
        // Initialize the countdown timer
        countdown = timeBeforeDisable;
    }

    void Update()
    {
        // Reduce the countdown timer
        countdown -= Time.deltaTime;

        // Check if the timer has finished
        if (countdown <= 0f)
        {
            DisableGameObject();
        }
    }

    private void DisableGameObject()
    {
        // Disable the GameObject
        gameObject.SetActive(false);
    }
}

