using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Glass,
    Weapons
}

[CreateAssetMenu(fileName = "ItemIn", menuName = "Inventory/ItemIn")]

public class ItemIn : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite image;
    public ItemType itemType;

    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


}