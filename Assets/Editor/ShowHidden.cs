using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public static class Constants
{
    public const string Hidden_Flag = "HiddenFlag";



}


public class ShowHidden : MonoBehaviour
{
    const string k_menu = "I wish to see all objects/Show Hidden Objects";

    private static List<GameObject> HiddenObjects = new List<GameObject>();

    private static bool AreHidden;

    [MenuItem(k_menu)]


    static void ShowHiddenMenueItem()
    {
        EditorPrefs.SetBool(Constants.Hidden_Flag, !EditorPrefs.GetBool(Constants.Hidden_Flag,false));
        AreHidden = EditorPrefs.GetBool(Constants.Hidden_Flag);
        if (AreHidden)
        {
            foreach (GameObject go in HiddenObjects) 
            {
                go.hideFlags = HideFlags.HideInHierarchy;


            }
        }
        else if(!AreHidden)
        {
           
            foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
            {
                //if(go.hideFlags != HideFlags.None) This didn't work but I wanted it so you could also hide them again
               // { 
               //  HiddenObjects.Add(go)
               // }
                    go.hideFlags = HideFlags.None;

            }

        }


        

    }


    [MenuItem(k_menu, true)]
    static bool ShowHiddenItemValidation()
    {
        Menu.SetChecked(k_menu, !EditorPrefs.GetBool(Constants.Hidden_Flag, false));
        return true;
    }

}
