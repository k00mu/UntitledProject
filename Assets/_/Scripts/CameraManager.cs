// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField] private bool isUseFollow;
	[SerializeField] private bool isUseLookAt;
	
	
	[Header("Virtual Cameras")] 
	[SerializeField] private List<CinemachineVirtualCamera> virtualCameraList = new List<CinemachineVirtualCamera>();
	
	[Header("Targets")]
	[SerializeField] private CinemachineTargetGroup targetGroup;
	
	
	
	#region OnValidate
	
	private void OnValidate()
	{
		// if not dirty, return
		if (virtualCameraList.Count == transform.childCount)
		{
			return;
		}
		
		// if there is no child, return
		if (transform.childCount == 0)
		{
			Debug.LogWarning($"[CameraManager] No child found in CameraManager. Please add child with CinemachineVirtualCamera component.");
		}
		
		PopulateVirtualCameraList();
	}


	private void PopulateVirtualCameraList()
	{
		virtualCameraList ??= new List<CinemachineVirtualCamera>();
		virtualCameraList.Clear();
		foreach (Transform child in transform)
		{
			if (!child.TryGetComponent(out CinemachineVirtualCamera virtualCamera)) continue;
			
			virtualCamera.m_StandbyUpdate = CinemachineVirtualCameraBase.StandbyUpdateMode.Never;
			
			if (isUseFollow)
			{
				virtualCamera.Follow = targetGroup.transform;
			}
			
			if (isUseLookAt)
			{
				virtualCamera.LookAt = targetGroup.transform;
			}

			virtualCameraList.Add(virtualCamera);
			Debug.Log($"[CameraManager] Child found with CinemachineVirtualCamera component: {child.name}");
		}
	}
	
	#endregion


	#region TargetGroup

	public void AddTarget(Transform _target, float _weight = 1, float _radius = 1)
	{
		targetGroup.AddMember(_target, _weight, _radius);
	}
	
	public void RemoveTarget(Transform _target)
	{
		targetGroup.RemoveMember(_target);
	}
	
	
	public int TargetCount => targetGroup.m_Targets.Length;

	#endregion
	

	#region VirtualCameras
	
	public CinemachineVirtualCamera GetVirtualCamera(int _index)
	{
		if (_index < 0 || _index >= virtualCameraList.Count)
		{
			Debug.LogError($"[CameraManager] Index out of range: {_index}");
			return null;
		}

		return virtualCameraList[_index];
	}
	
	public CinemachineVirtualCamera GetVirtualCamera(string _name)
	{
		foreach (CinemachineVirtualCamera virtualCamera in virtualCameraList)
		{
			if (virtualCamera.name == _name)
			{
				return virtualCamera;
			}
		}

		Debug.LogError($"[CameraManager] VirtualCamera not found with name: {_name}");
		return null;
	}
	
	
	public void SetActiveVirtualCamera(int _index)
	{
		if (_index < 0 || _index >= virtualCameraList.Count)
		{
			Debug.LogError($"[CameraManager] Index out of range: {_index}");
			return;
		}

		foreach (CinemachineVirtualCamera virtualCamera in virtualCameraList)
		{
			if (virtualCamera == virtualCameraList[_index])
			{
				virtualCamera.gameObject.SetActive(true);
				continue;
			}
			
			if (virtualCamera.gameObject.activeSelf)
			{
				virtualCamera.gameObject.SetActive(false);
			}
		}
	}
	
	#endregion
	
	
}
