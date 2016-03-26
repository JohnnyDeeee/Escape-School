using UnityEngine;
using System.Collections;
using System;

public class AddScrewdriver : Interactable
{
    public override void Action()
    {
        //Add 1 screwdriver
        GameManager.gui.inventory.AddItem(GameManager.itemDatabase.Find(x => x.ItemName == "Screwdriver"));
        GameManager.gui.ShowHint("Item(s) Found", "You found a screwdriver! Look for screws to unscrew them (duhh)", 3.0f);
        Destroy(gameObject);
    }
}
