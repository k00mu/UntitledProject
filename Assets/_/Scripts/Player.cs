// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private Transform cameraReferenceTransform;
	public Transform CameraReferenceTransform => cameraReferenceTransform;
	
	[SerializeField] private PlayerController playerController;
	
	[SerializeField] private List<ItemSO> inventory = new List<ItemSO>();
	
	[SerializeField] private CollectAbility collectAbility;


	private void OnEnable()
	{
		collectAbility.OnPerform += CollectAbility_OnPerform;
	}


	private void CollectAbility_OnPerform(Collider _obj)
	{
		if (_obj.TryGetComponent(out Item item))
		{
			inventory.Add(item.ReferenceSO);
			item.Collect();
		}
	}
}
