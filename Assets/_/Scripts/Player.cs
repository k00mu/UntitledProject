// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;

public class Player : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private Transform cameraReferenceTransform;
	public Transform CameraReferenceTransform => cameraReferenceTransform;
	
	[Header("Components")]
	[SerializeField] private PlayerController playerController;
	[Header("Abilties")]
	[SerializeField] private CollectAbility collectAbility;

	private Inventory playerInventory;
	public Inventory PlayerInventory => playerInventory;


	private void Awake()
	{
		playerInventory = new Inventory();
	}


	private void OnEnable()
	{
		collectAbility.OnPerform += CollectAbility_OnPerform;
	}


	private void CollectAbility_OnPerform(Collider _obj)
	{
		if (!_obj.TryGetComponent(out Item item)) return;
		
		playerInventory.AddItem(item.ReferenceSO, 1);
		item.Collect();
	}
}
