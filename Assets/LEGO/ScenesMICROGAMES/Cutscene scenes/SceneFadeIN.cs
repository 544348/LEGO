using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFadeIN : MonoBehaviour
{
    // The panel to fade in
    public Image panel;

    // The speed of the fade in
    public float fadeInSpeed = 1.0f;

    // Whether the fade in has started
    private bool isFadingIn = false;

    // The current opacity of the panel
    private float currentAlpha = 0f;

    void Start()
    {
        if (panel == null)
        {
            Debug.LogError("Panel not assigned. Please assign a UI Image component to the panel variable.");
            return;
        }

        // Initialize the current alpha value to 0 (completely transparent)
        currentAlpha = 0f;

        // Set the initial color of the panel to be transparent
        Color initialColor = panel.color;
        initialColor.a = currentAlpha;
        panel.color = initialColor;
    }

    void Update()
    {
        // If fading in is enabled, increase the alpha value over time
        if (isFadingIn)
        {
            currentAlpha += Time.deltaTime * fadeInSpeed;

            // Clamp the alpha value to be between 0 and 1
            currentAlpha = Mathf.Clamp(currentAlpha, 0, 1);

            // Update the panel's color with the new alpha value
            Color newColor = panel.color;
            newColor.a = currentAlpha;
            panel.color = newColor;

            // If the alpha value is 1, stop the fade in
            if (currentAlpha == 1)
            {
                isFadingIn = false;
            }
        }
    }

    // Method to start the fade in process
    public void StartFadeIn()
    {
        isFadingIn = true;
    }
}