// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;
using UnityEngine.EventSystems;


public class MouseWorld : MonoBehaviour
{
	private static Camera targetCamera;



	private void Awake()
	{
		targetCamera = Camera.main;
	}
	
	
	public static Vector3 GetPosition()
	{
		Ray ray = targetCamera.ScreenPointToRay(Input.mousePosition);

		if (EventSystem.current.IsPointerOverGameObject())
		{
			return Vector3.zero;
		}
		
		return Physics.Raycast(ray, out RaycastHit raycastHitInfo, float.MaxValue, MainResources.Instance.groundLayerMask)
			? raycastHitInfo.point
			: Vector3.zero;
	}
	
	
	public static Vector3 GetPosition(int _touchIndex)
	{
		Touch touch = Input.GetTouch(_touchIndex);
		Ray ray = targetCamera.ScreenPointToRay(touch.position);
		
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return Vector3.zero;
		}

		return Physics.Raycast(ray, out RaycastHit raycastHitInfo, float.MaxValue, MainResources.Instance.groundLayerMask)
			? raycastHitInfo.point
			: Vector3.zero;
	}	
}

