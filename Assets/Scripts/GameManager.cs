
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public static class GameManager
{
    public static GameObject pr_hint;
    private static bool initialized = false;
    private static Interface gui;

    //One-time initialization
    public static void Initialize()
    {
        if (!initialized)
        {
            //Load resources
            pr_hint = Resources.Load<GameObject>("Prefabs/GUI/Hint");

            //Get the interface script
            gui = GameObject.Find("GUI").GetComponent<Interface>();

            //End of initialization
            initialized = true; 
        }
    }
}
