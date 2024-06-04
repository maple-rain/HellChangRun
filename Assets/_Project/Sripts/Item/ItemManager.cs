using UnityEngine;

internal class ItemManager: Singleton<ItemManager>
{
    public Item _item;
    public Item Item
    {
        get { return _item; }
        set { _item = value; }
    }
}