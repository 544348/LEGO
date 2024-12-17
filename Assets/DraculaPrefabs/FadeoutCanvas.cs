using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeoutCanvas : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeOutTime = 5f; // Time after which the fade out starts
    public float fadeOutDuration = 2f; // Duration of the fade out

    private float timer = 2f;
    private bool startFadeOut = false;

    void Start()
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fadeOutTime)
        {
            startFadeOut = true;
        }

        if (startFadeOut)
        {
            float alpha = Mathf.Lerp(1f, 0f, (timer - fadeOutTime) / fadeOutDuration);
            canvasGroup.alpha = alpha;

            if (alpha <= 0f)
            {
                startFadeOut = false; // Stop fading out once fully transparent
            }
        }
    }
}