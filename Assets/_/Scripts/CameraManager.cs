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
			LogHelper.LogError(nameof(CameraManager), nameof(GetVirtualCamera), $"Index out of range: {_index}");
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

		LogHelper.LogError(nameof(CameraManager), nameof(GetVirtualCamera), $"VirtualCamera not found with name: {_name}");
		return null;
	}
	
	
	public void SetActiveVirtualCamera(int _index)
	{
		if (_index < 0 || _index >= virtualCameraList.Count)
		{
			LogHelper.LogError(nameof(CameraManager), nameof(SetActiveVirtualCamera), $"Index out of range: {_index}");
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
	
		
	#region OnValidate

	#if UNITY_EDITOR
	
	private void OnValidate()
	{
		// validate helper checks
		ValidateHelper.CheckNull(targetGroup, nameof(targetGroup), nameof(CameraManager));
		
		// dirty checks
		if (virtualCameraList.Count == transform.childCount)
		{
			return;
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
		}
	}

	#endif
	
	#endregion

}
