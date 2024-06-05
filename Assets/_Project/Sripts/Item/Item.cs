using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData item;

    private void Awake()
    {
        ItemManager.Instance.Item = this;
    }

}
