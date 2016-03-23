using UnityEngine;
using System.Collections;
using System;

public class TempObject : Interactable
{
    public override void Action()
    {
        Debug.Log("Action is called from TempObject!");
    }
}
