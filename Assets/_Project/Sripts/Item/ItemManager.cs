using System.Collections.Generic;
using UnityEngine;

internal class ItemManager: Singleton<ItemManager>
{
    public Item _item;
    public Item Item
    {
        get { return _item; }
        set { _item = value; }
    }
    public Inventory _inventory;
    public Inventory Inventory
    {
        get { return _inventory; }
        set { _inventory = value; }
    }

    public ItemData[] SelectedItemDates = new ItemData[4];
}