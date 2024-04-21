// ==================================================
// 
//   Created by atqamz
// 
// ==================================================

using System;
using UnityEngine;

public class Dumpster : MonoBehaviour
{
	[Header("Visual")]
	[SerializeField] private Transform visualTransform;
	
	[Header("Points")]
	[SerializeField] private Transform popUpPoint;
	
	[Header("References")]
	[SerializeField] private SphereCollider sphereCollider;



	private void OnTriggerEnter(Collider _other)
	{
		Debug.Log("Dumpster Triggered");
		GameManager.Instance.ActivePlaySpace.CallToActionPopUpCanvas.SetFollowTarget(popUpPoint);
		GameManager.Instance.ActivePlaySpace.CallToActionPopUpCanvas.ShowPopUp(() =>
		{
			Debug.Log("Dumpster PopUp Clicked");
		});
	}
	

	private void OnTriggerExit(Collider _other)
	{
		Debug.Log("Dumpster Exited");
		GameManager.Instance.ActivePlaySpace.CallToActionPopUpCanvas.HidePopUp();
	}
	


	#region OnValidate
	
	#if UNITY_EDITOR
	private void OnValidate()
	{
		// validate helper checks
		ValidateHelper.CheckNull(popUpPoint, nameof(popUpPoint), nameof(Dumpster));
		
		sphereCollider.center = visualTransform.localPosition;
	}
	#endif
	
	#endregion
}
