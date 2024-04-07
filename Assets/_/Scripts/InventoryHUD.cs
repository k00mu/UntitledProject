// ==================================================
//
//   Created by Atqa Munzir
//
// ==================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHUD : MonoBehaviour
{
    [SerializeField] private InventoryItem inventoryItemPrefab;
    private Inventory inventory;
    private List<InventoryItem> inventoryItemList = new List<InventoryItem>();

    private void OnEnable()
    {
        Initialize();
    }
    
    private void Initialize()
    {
        StartCoroutine(_());
        
        IEnumerator _()
        {
            yield return new WaitUntil(() => GameManager.Instance.ActivePlaySpace != null);
            inventory = GameManager.Instance.ActivePlaySpace.ActivePlayer.PlayerInventory;
        
            inventory.OnItemAdded += Inventory_OnItemAdded;
            inventory.OnItemRemoved += Inventory_OnItemRemoved;
        }
    }
    
    private void OnDisable()
    {
        inventory.OnItemAdded -= Inventory_OnItemAdded;
        inventory.OnItemRemoved -= Inventory_OnItemRemoved;
    }

    private void AddItem(ItemSO _itemSO, int _amount)
    {
        InventoryItem inventoryItem = inventoryItemList.Find(_item => _item.ReferenceSO == _itemSO);
        if (inventoryItem == null)
        {
            inventoryItem = Instantiate(inventoryItemPrefab, transform);
            inventoryItem.Initialize(_itemSO, _amount);
            inventoryItemList.Add(inventoryItem);
        }
        
        inventoryItem.SetAmount(_amount);
    }

    private void RemoveItem(ItemSO _itemSO, int _amount)
    {
        InventoryItem inventoryItem = inventoryItemList.Find(_item => _item.ReferenceSO == _itemSO);
        if (inventoryItem == null) return;
        
        if (_amount <= 0)
        {
            inventoryItemList.Remove(inventoryItem);
            Destroy(inventoryItem.gameObject);
        }
        else
        {
            inventoryItem.SetAmount(_amount);
        }
    }
    
    private void Inventory_OnItemAdded(ItemSO _itemSO, int _amount)
    {
        AddItem(_itemSO, _amount);
    }
    
    private void Inventory_OnItemRemoved(ItemSO _itemSO, int _amount)
    {
        RemoveItem(_itemSO, _amount);
    }
}
