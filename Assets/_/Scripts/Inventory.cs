// ==================================================
//
//   Created by Atqa Munzir
//
// ==================================================

using System;
using System.Collections.Generic;

[Serializable]
public class Inventory
{
    private Dictionary<ItemSO, int> inventoryDict;
    public Action<ItemSO, int> OnItemAdded;
    public Action<ItemSO, int> OnItemRemoved;
    
    public Inventory() {
        inventoryDict = new Dictionary<ItemSO, int>();
    }

    
    public void AddItem(ItemSO item, int quantity) {
        if (inventoryDict.ContainsKey(item)) {
            // If the item already exists in the inventory, update its quantity
            inventoryDict[item] += quantity;
        } else {
            // Otherwise, add the item to the inventory with the specified quantity
            inventoryDict[item] = quantity;
        }
        OnItemAdded?.Invoke(item, quantity);
    }

    
    public void RemoveItem(ItemSO item, int quantity) {
        if (inventoryDict.ContainsKey(item)) {
            // If the item exists in the inventory, decrement its quantity
            inventoryDict[item] -= quantity;
            // Check if the quantity becomes zero or negative, and remove the item if so
            if (inventoryDict[item] <= 0) {
                inventoryDict.Remove(item);
            }
        } else {
            // Handle the case where the item doesn't exist in the inventory
            // This could be an error condition or just a no-op depending on your requirements
            // Here, I'm throwing an exception to indicate that the item doesn't exist
            throw new KeyNotFoundException("Item not found in inventory");
        }
        OnItemRemoved?.Invoke(item, quantity);
    }

    
    public int GetItemQuantity(ItemSO item) {
        if (inventoryDict.ContainsKey(item)) {
            return inventoryDict[item];
        } else {
            // If the item doesn't exist in the inventory, return 0 or throw an exception
            // Here, I'm returning 0 to indicate that the item isn't present
            return 0;
        }
    }
}