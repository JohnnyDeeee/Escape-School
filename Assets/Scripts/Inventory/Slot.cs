using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{    
    public int index;
    public int amount = 0;
    public Item Item { get { return item; } }

    private Item item;
    private Sprite empty;

    void Start () {
        //Create click event
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        UnityAction<BaseEventData> call = new UnityAction<BaseEventData>(GameManager.gui.ClickOnSlot);
        entry.callback.AddListener(call);
        trigger.triggers.Add(entry);

        //Set "empty" image
        empty = transform.FindChild("Item").GetComponent<Image>().sprite;
    }
	
	void Update () {
        //Set image for item
        if (item != null)
        {
            transform.FindChild("Item").GetComponent<Image>().sprite = item.Image;

            //Only show amount if it
            //is necessary
            if (item.Stackable)
            {
                //Set amount
                transform.FindChild("Amount").GetComponent<Text>().text = amount.ToString();

                //Show amount
                transform.FindChild("Amount").gameObject.SetActive(true);
            }
            //Hide amount
            else
            {
                transform.FindChild("Amount").gameObject.SetActive(false);
            }

            //If itemstack is empty
            //then we have no items
            //in this slot
            if (amount <= 0 && item.Stackable)
            {
                item = null;
            }
        }
        else
        {
            transform.FindChild("Item").GetComponent<Image>().sprite = empty;
            transform.FindChild("Amount").gameObject.SetActive(false);
        }
    }

    //Adds item to the slot
    public void AddItem(Item item, int amount = 1)
    {
        //Change item
        this.item = item;
        
        //Increase the stack of the item if
        //that is allowed
        if (this.item.Stackable)
        {
            //Add amount
            if ((this.amount + amount) <= this.item.MaxStack)
            {
                this.amount += amount;
            }
            //Just fill the amount
            //to the max
            else
            {
                this.amount = item.MaxStack;
            }
        }
    }

    //Removes item from the slot
    public void RemoveItem(int amount, bool flushWholeStack = false)
    {
        if (item != null)
        {
            //Decrease amount
            if (item.Stackable)
            {
                //Flush whole item stack
                if (amount >= this.amount || flushWholeStack)
                {
                    this.amount = 0;
                }
                //Decrease item stack by specified
                //amount
                else
                {
                    this.amount -= amount;
                }
            }
            //Remove item because
            //there is the stack is 1
            else
            {
                item = null;
            }
        }
    }
}
