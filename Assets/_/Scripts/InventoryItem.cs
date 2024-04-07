// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class InventoryItem : MonoBehaviour
{
    [SerializeField] private ItemSO referenceSO;
    public ItemSO ReferenceSO { get => referenceSO; set => referenceSO = value; }

    [SerializeField] private Image itemImage;    
    [SerializeField] private TextMeshProUGUI itemAmountText;

    public void SetAmount(int _amount)
    {
        itemAmountText.text = _amount.ToString();
    }

    public void Initialize(ItemSO _itemSO, int _amount)
    {
        referenceSO = _itemSO;
        // itemImage.sprite = _itemSO.Icon;
        itemAmountText.text = _amount.ToString();
    }
}
