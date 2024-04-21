// ==================================================
// 
//   Created by atqamz
// 
// ==================================================

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CallToActionPopUpCanvas : CanvasWrapper
{
	[SerializeField] private FollowWorldObject followWorldObject;
	
	
	public void ShowPopUp(UnityAction _onClick)
	{
		EnableCanvas();
		followWorldObject.Button.onClick.AddListener(_onClick);
	}
	
	
	public void HidePopUp()
	{
		followWorldObject.GetComponent<Button>().onClick.RemoveAllListeners();
		DisableCanvas();
	}
	
	
	public void SetFollowTarget(Transform _targetTransform, Vector3 _offset = default)
	{
		followWorldObject.TargetTransform = _targetTransform;
		followWorldObject.Offset = _offset;
	}
}
