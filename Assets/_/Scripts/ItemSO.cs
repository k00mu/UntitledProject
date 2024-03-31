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
}
