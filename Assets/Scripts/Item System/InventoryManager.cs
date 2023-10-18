using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    List<Item> inventoryList = new List<Item>();

    public void AddItemToInventory(Item item)
    {
        inventoryList.Add(item);
    }

    public void RemoveItemFromInventory(Item item)
    {
        inventoryList.Remove(item);
    }

    public bool HasItemInInventory(Item item)
    {
        return inventoryList.Contains(item);
    }
}