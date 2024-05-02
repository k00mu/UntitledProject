// ==================================================
// 
//   Created by atqamz
// 
// ==================================================

using UnityEngine;
using UnityEngine.EventSystems;

namespace UntitledProject.Scripts
{
	public class WorldPointer : MonoBehaviour
	{
		private static Camera targetCamera;
		[SerializeField] private static LayerMask targetLayerMask;



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
		
			return Physics.Raycast(ray, out RaycastHit raycastHitInfo, float.MaxValue, targetLayerMask)
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
}
