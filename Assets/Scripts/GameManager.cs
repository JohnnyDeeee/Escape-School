
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    private static bool initialized = false;
    private static Sprite im_key, im_screwdriver, im_battery;

    public static GameObject pr_hint, pr_slot;
    public static List<Item> itemDatabase;
    public static Interface gui;
    public static int totalItems;

    //One-time initialization
    public static void Initialize()
    {
        if (!initialized)
        {
            //Load resources
            //Prefabs
            pr_hint = Resources.Load<GameObject>("Prefabs/GUI/Hint");
            pr_slot = Resources.Load<GameObject>("Prefabs/GUI/Inventory/Slot");
            //Images
            im_key = Resources.Load<Sprite>("Sprites/GUI/Inventory/Items/Key");
            im_screwdriver = Resources.Load<Sprite>("Sprites/GUI/Inventory/Items/Screwdriver");
            im_battery = Resources.Load<Sprite>("Sprites/GUI/Inventory/Items/Battery");

            //Create items
            itemDatabase = new List<Item>();
            itemDatabase.Add(new Item(false, 0, "Key", "This key unlocks something", im_key));
            itemDatabase.Add(new Item(false, 0, "Screwdriver", "This is a handy tool for unscrewing things (except for unscrewing your life.. that doesn't work...)", im_screwdriver));
            itemDatabase.Add(new Item(true, 5, "Battery", "Used to power devices. Don't lick it!", im_battery));

            //Get the interface script
            gui = GameObject.Find("GUI").GetComponent<Interface>();

            //Fill inventory with slots
            gui.inventory.Initialize();

            //End of initialization
            initialized = true; 
        }
    }
}
