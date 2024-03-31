// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Game/Item")]
public class ItemSO : ScriptableObject
{
	public GameObject itemPrefab;
	
	public string itemName;

	
	#region OnValidate
	
	#if UNITY_EDITOR

	private void OnValidate()
	{
		// validate helper checks
		ValidateHelper.CheckNull(itemPrefab, nameof(itemPrefab), nameof(ItemSO));

		// null then assign checks
		if (!itemPrefab.TryGetComponent(out Item item))
		{
			Debug.LogWarning($"[ItemSO] Item Prefab does not have Item component. Please add Item component on {itemPrefab.name} prefab");
			itemPrefab.AddComponent<Item>();
		}
		
		itemName ??= itemPrefab.name;
		item.ReferenceSO ??= this;
	}

	#endif

	#endregion
}
