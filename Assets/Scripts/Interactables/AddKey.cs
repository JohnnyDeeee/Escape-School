using UnityEngine;
using System.Collections;
using System;

public class AddKey : Interactable
{
    public override void Action()
    {
        //Add 1 key
        GameManager.gui.inventory.AddItem(GameManager.itemDatabase.Find(x => x.ItemName == "Key"));
        GameManager.gui.ShowHint("Item(s) Found", "You found a key!", 3.0f);
    }
}
