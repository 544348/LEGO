using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour
{
    // The panel to fade out
    public Image panel;

    // The speed of the fade out
    public float fadeOutSpeed = 1.0f;

    // Whether the fade out has started
    private bool isFadingOut = false;

    // The current opacity of the panel
    private float currentAlpha;

    void Start()
    {
        StartFadeOut();
        if (panel == null)
        {
            Debug.LogError("Panel not assigned. Please assign a UI Image component to the panel variable.");
            return;
        }

        // Initialize the current alpha value to the panel's current alpha
        currentAlpha = panel.color.a;
    }

    void Update()
    {
        // If fading out is enabled, reduce the alpha value over time
        if (isFadingOut)
        {
            currentAlpha -= Time.deltaTime * fadeOutSpeed;

            // Clamp the alpha value to be between 0 and 1
            currentAlpha = Mathf.Clamp(currentAlpha, 0, 1);

            // Update the panel's color with the new alpha value
            Color newColor = panel.color;
            newColor.a = currentAlpha;
            panel.color = newColor;

            // If the alpha value is 0, stop the fade out
            if (currentAlpha == 0)
            {
                isFadingOut = false;
            }
        }
    }

    // Method to start the fade out process
    public void StartFadeOut()
    {
        isFadingOut = true;
    }
}
