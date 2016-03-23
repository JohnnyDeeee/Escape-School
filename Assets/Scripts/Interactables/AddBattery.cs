using UnityEngine;
using System.Collections;
using System;

public class AddBattery : Interactable
{
    public override void Action()
    {
        //Add 2 batteries
        GameManager.gui.inventory.AddItem(GameManager.itemDatabase.Find(x => x.ItemName == "Battery"), 2);
        GameManager.gui.ShowHint("Item(s) Found", "Yay! You found 2 batteries!", 3.0f);
    }
}
