using UnityEngine;

public class Item
{
    private int itemID;
    private bool stackable;
    private int maxStack;
    private string itemName;
    private string itemDescription;
    private Sprite image;

    public int ItemID { get { return itemID; } set { itemID = value; } }
    public bool Stackable { get { return stackable; } set { stackable = value; } }
    public int MaxStack { get { return maxStack; } set { maxStack = value; } }
    public string ItemName { get { return itemName; } set { itemName = value; } }
    public string ItemDescription { get { return itemDescription; } set { itemDescription = value; } }
    public Sprite Image { get { return image; } set { image = value; } }

    public Item(bool stackable, int maxStack, string itemName, string itemDescription, Sprite image)
    {
        this.ItemID = GameManager.totalItems + 1;
        this.stackable = stackable;
        this.maxStack = maxStack;
        this.itemName = itemName;
        this.itemDescription = itemDescription;
        this.image = image;

        GameManager.totalItems += 1;
    }
}
