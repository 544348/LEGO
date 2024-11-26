using UnityEngine;
using TMPro;

public class TextFadeEffect : MonoBehaviour
{
    public TextMeshProUGUI textElement; // Assign your TextMeshProUGUI object in the Inspector
    public float fadeDuration = 2f;    // Time for a full fade in and out cycle

    private Color originalColor;

    void Start()
    {
        if (textElement == null)
        {
            Debug.LogError("Text Element is not assigned!");
            return;
        }

        // Save the original color of the text (including alpha)
        originalColor = textElement.color;
    }

    void Update()
    {
        if (textElement == null) return;

        // Calculate the alpha value using PingPong
        float alpha = Mathf.PingPong(Time.time / fadeDuration, 1f);

        // Update the text color with the new alpha
        textElement.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
    }
}