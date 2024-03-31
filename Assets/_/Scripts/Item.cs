// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;

public class Item : MonoBehaviour, ICollectable
{
	[SerializeField] private ItemSO referenceSO;
	public ItemSO ReferenceSO { get => referenceSO; set => referenceSO = value; }
	
	
	public void Collect()
	{
		Debug.Log($"[Item] Collected {name}");
		Destroy(gameObject);
	}
}
