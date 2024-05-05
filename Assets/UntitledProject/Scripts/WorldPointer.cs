// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UntitledProject.Scripts
{
	public class WorldPointer : MonoBehaviour
	{
		private static Camera _targetCamera;
		private static LayerMask _targetLayerMask;


		private void Awake()
		{
			_targetCamera = Camera.main;
			_targetLayerMask = LayerMask.GetMask(GlobalSetting.GroundLayerMask);
		}
	
	
		public static Vector3 GetPosition()
		{
			Ray ray = _targetCamera.ScreenPointToRay(Input.mousePosition);

			if (EventSystem.current.IsPointerOverGameObject())
			{
				return Vector3.zero;
			}

			return Physics.Raycast(ray, out RaycastHit raycastHitInfo, float.MaxValue, _targetLayerMask)
				? raycastHitInfo.point
				: Vector3.zero;
		}


		public static Vector3 GetPosition(int touchIndex)
		{
			Touch touch = Input.GetTouch(touchIndex);
			Ray ray = _targetCamera.ScreenPointToRay(touch.position);

			if (EventSystem.current.IsPointerOverGameObject())
			{
				return Vector3.zero;
			}

			return Physics.Raycast(ray, out RaycastHit raycastHitInfo, float.MaxValue, _targetLayerMask)
				? raycastHitInfo.point
				: Vector3.zero;
		}
	}
}
