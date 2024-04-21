// ==================================================
// 
//   Created by atqamz
// 
// ==================================================

using UnityEngine;
using UnityEngine.AI;

public class Dumpster : MonoBehaviour
{
	[Header("Visual")]
	[SerializeField] private Transform visualTransform;
	
	[Header("Points")]
	[SerializeField] private Transform popUpPoint;
	
	[Header("References")]
	[SerializeField] private SphereCollider sphereCollider;
	[SerializeField] private NavMeshObstacle navMeshObstacle;



	private void OnTriggerEnter(Collider _other)
	{
		GameManager.Instance.ActivePlaySpace.CallToActionPopUpCanvas.SetFollowTarget(popUpPoint);
		GameManager.Instance.ActivePlaySpace.CallToActionPopUpCanvas.ShowPopUp(() =>
		{
			Debug.Log("Dumpster PopUp Clicked");
		});
	}
	

	private void OnTriggerExit(Collider _other)
	{
		GameManager.Instance.ActivePlaySpace.CallToActionPopUpCanvas.HidePopUp();
	}
	


	#region OnValidate
	
	#if UNITY_EDITOR
	private void OnValidate()
	{
		// validate helper checks
		ValidateHelper.CheckNull(popUpPoint, nameof(popUpPoint), nameof(Dumpster));
		ValidateHelper.CheckNull(sphereCollider, nameof(sphereCollider), nameof(Dumpster));
		ValidateHelper.CheckNull(navMeshObstacle, nameof(navMeshObstacle), nameof(Dumpster));
		
		sphereCollider.center = visualTransform.localPosition;
		navMeshObstacle.center = visualTransform.localPosition;
	}
	#endif
	
	#endregion
}
