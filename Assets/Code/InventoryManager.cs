using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    public Transform itemHolder;
    public GameObject itemPrefab;
    public Toggle enableRemoveItem;
    // Start is called before the first frame update
    public static InventoryManager Instance { get; private set; }
    public List<ItemIn> items = new List<ItemIn>();
    void Awake()
    {
        if (Instance != null || Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
    }
    public void Add(ItemIn item)
    {

        items.Add(item);
        DisplayInventory();
    }
    public void Remove(ItemIn item)
    {
        items.Remove(item);
    }
    public void DisplayInventory()
    {
        foreach (Transform item in itemHolder)
            Destroy(item.gameObject);
        foreach (ItemIn item in items)
        {
            GameObject obj = Instantiate(itemPrefab, itemHolder);
            TextMeshProUGUI itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            Image itemImage = obj.transform.Find("ItemImage").GetComponent<Image>();
            itemName.text = item.itemName;
            itemImage.sprite = item.image;

            obj.GetComponent<ItemUIController>().SetItem(item);

        }
        EnbleRemoveButton();
    }
    void EnbleRemoveButton()
    {
        if (enableRemoveItem.isOn)
        {
            foreach (Transform item in itemHolder)
            {
                item.transform.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in itemHolder)
            {
                item.transform.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }
}
