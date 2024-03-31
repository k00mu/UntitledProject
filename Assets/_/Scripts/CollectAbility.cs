// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class CollectAbility : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField] private float radius = 0.75f;
	[SerializeField] private float height = 5f;
	[SerializeField] private LayerMask targetLayerMask;

	public Action<Collider> OnPerform;


	private void OnTriggerEnter(Collider _other)
	{
		if ((targetLayerMask.value & 1 << _other.gameObject.layer) <= 0)
		{
			return;
		}

		LogHelper.Log(nameof(CollectAbility), nameof(OnTriggerEnter), $"Collecting {_other.name}");
		OnPerform?.Invoke(_other);
	}
	
	
	#region OnValidate
	
	#if UNITY_EDITOR
	private void OnValidate()
	{
		// validate helper checks
		ValidateHelper.CheckZero(targetLayerMask, nameof(targetLayerMask), nameof(CollectAbility));
		
		// null then assign checks
		if (!TryGetComponent(out CapsuleCollider capsuleCollider))
		{
			Debug.LogWarning($"[CollectAbility] CapsuleCollider component not found. Adding CapsuleCollider component on {name} GameObject");
			capsuleCollider = gameObject.AddComponent<CapsuleCollider>();
		}
		
		// dirty checks
		if (!capsuleCollider.isTrigger)
		{
			capsuleCollider.isTrigger = true;
		}
		if (!(Math.Abs(capsuleCollider.radius - radius) < GeneralPreferences.DEFAULT_TOLERANCE) ||
		    !(Math.Abs(capsuleCollider.height - height) < GeneralPreferences.DEFAULT_TOLERANCE))
		{
			capsuleCollider.radius = radius;
			capsuleCollider.height = height;
		}
	}
	
	#endif
	
	#endregion
	
}
