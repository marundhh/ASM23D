using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUIController : MonoBehaviour
{
   
    public ItemIn item;
    public void SetItem(ItemIn item)
    {
        this.item = item;
    }
    public void Remove()
    {
        InventoryManager.Instance.Remove(item);
        Destroy(this.gameObject);
    }
    public void UseItem()
    {
        Remove();

        switch (item.itemType)
        {
            case ItemType.Glass:
                FindObjectOfType<GameSession>().IncreaseHealth(item.value);
                break;

            case ItemType.Weapons:
                FindObjectOfType<GameSession>().IncreaseHealth(-item.value);
                break;
        }
    }
}
