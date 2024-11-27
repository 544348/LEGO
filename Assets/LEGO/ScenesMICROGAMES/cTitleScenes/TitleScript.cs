using UnityEngine;
using TMPro; // Make sure you have the TextMeshPro package installed

public class TitleScript : MonoBehaviour
{
    public GameObject[] tmpTextElements;
    public GameObject[] targetGameObjects;

    // Update is called once per frame
    
    void Update()
    {
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            foreach (GameObject tmpElement in tmpTextElements)
            {
                if (tmpElement != null)
                {
                    tmpElement.SetActive(false);
                }
            }
            foreach (GameObject targetObject in targetGameObjects)
            {
                if (targetObject != null)
                {
                    targetObject.SetActive(true);
                }
            }
        }
    }
}