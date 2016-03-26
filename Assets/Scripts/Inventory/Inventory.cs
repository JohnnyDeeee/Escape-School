using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    public Slot selectedSlot;

    [SerializeField] private GameObject grid;
    private List<Slot> slots;
    private int maxSlots = 24;

    public void Initialize() {
        slots = new List<Slot>();

        for (int i = 0; i < maxSlots; i++)
        {
            GameObject slot = Instantiate(GameManager.pr_slot);
            slot.transform.SetParent(grid.transform, false);
            slot.GetComponent<Slot>().index = i;
            slots.Add(slot.GetComponent<Slot>());
        }
	}

    //Adds item to the inventory
    public void AddItem(Item item, int amount = 1)
    {
        //Find a free slot
        foreach (Slot slot in slots)
        {
            //Slot is empty
            if (slot.Item == null)
            {
                slot.AddItem(item, amount);
                break;
            }

            //Add to a existing stack (if it is not already full)
            if (slot.Item == item && item.Stackable && slot.amount < item.MaxStack)
            {
                //Overfilling slot
                if (slot.amount + amount > item.MaxStack)
                {
                    int oldSlotAmount = slot.amount;
                    slot.AddItem(item, item.MaxStack - slot.amount);
                    AddItem(item, amount - (item.MaxStack - oldSlotAmount)); //Finds a new slot for the remaining amounts
                }
                else
                {
                    slot.AddItem(item, amount);
                }

                break;
            }
        }
    }

    //Removes item from te inventory
    public void RemoveItem(Item item, int amount = 1, Slot slot = null)
    {
        
        if (slot == null)
        {
            //Find the item in a slot
            foreach (Slot s in slots)
            {
                //Slot has our item
                if (s.Item == item)
                {
                    s.RemoveItem(amount);
                }
            }
        }
        else
        {
            slot.RemoveItem(amount);
        }
    }

    //Searches for the secified item
    public Item GetItem(Item item)
    {
        //Find the item
        foreach (Slot slot in slots)
        {
            //Slot has our item
            if (slot.Item == item)
            {
                return item;
            }
        }

        //Item not found
        return null;
    }
}
