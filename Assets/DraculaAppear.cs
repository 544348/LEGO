using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraculaAppear : MonoBehaviour
{
    [Header("Target GameObject")]
    [Tooltip("The GameObject to activate after the delay.")]
    public GameObject targetObject;

    [Header("Activation Delay")]
    [Tooltip("Time in seconds before the target GameObject is activated.")]
    public float delay = 5f;

    private void Start()
    {
        if (targetObject != null)
        {
            // Start the activation process
            StartCoroutine(ActivateObjectAfterDelay());
        }
        else
        {
            Debug.LogWarning("Target object is not assigned!", this);
        }
    }

    private System.Collections.IEnumerator ActivateObjectAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Activate the target object
        targetObject.SetActive(true);
    }
}