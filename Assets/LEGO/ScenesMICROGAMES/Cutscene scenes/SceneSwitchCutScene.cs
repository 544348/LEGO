using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class SceneSwitchCutScene : MonoBehaviour
{
    [Tooltip("Name of the scene to load after the timer ends.")]
    public string sceneToLoad;

    [Tooltip("Time in seconds before switching to the new scene.")]
    public float timer = 5f;

    private float countdown;

    void Start()
    {
        if (string.IsNullOrEmpty(sceneToLoad))
        {
            Debug.LogError("Scene to load is not set! Please set the 'Scene To Load' field in the Inspector.");
            enabled = false; // Disable the script if no scene is specified
        }

        countdown = timer; // Initialize the countdown timer
    }

    void Update()
    {
        // Reduce the countdown timer
        countdown -= Time.deltaTime;

        // Check if the timer has finished
        if (countdown <= 0f)
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
