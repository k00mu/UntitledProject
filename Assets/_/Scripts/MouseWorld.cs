// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;


public class MouseWorld : MonoBehaviourSingleton<MouseWorld>
{
	private Camera targetCamera;



	protected override void Awake()
	{
		base.Awake();
		
		targetCamera = Camera.main;
	}
	
	
	public static Vector3 GetPosition()
	{
		Ray ray = Instance.targetCamera.ScreenPointToRay(Input.mousePosition);

		return Physics.Raycast(ray, out var raycastHitInfo, float.MaxValue, MainResources.Instance.groundLayerMask)
			? raycastHitInfo.point
			: Vector3.zero;
	}
	
	
	public static Vector3 GetPosition(int _touchIndex)
	{
		Touch touch = Input.GetTouch(_touchIndex);
		Ray ray = Instance.targetCamera.ScreenPointToRay(touch.position);

		return Physics.Raycast(ray, out var raycastHitInfo, float.MaxValue, MainResources.Instance.groundLayerMask)
			? raycastHitInfo.point
			: Vector3.zero;
	}
}

