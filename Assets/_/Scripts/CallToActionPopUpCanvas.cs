// ==================================================
// 
//   Created by atqamz
// 
// ==================================================

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CallToActionPopUpCanvas : MonoBehaviour
{
	[SerializeField] private Canvas canvas;
	[SerializeField] private CanvasScaler canvasScaler;
	[SerializeField] private GraphicRaycaster graphicRaycaster;
	
	[SerializeField] private FollowWorldObject followWorldObject;
	
	
	public void ShowPopUp(UnityAction _onClick)
	{
		canvas.enabled = true;
		canvasScaler.enabled = true;
		graphicRaycaster.enabled = true;
		
		followWorldObject.Button.onClick.AddListener(_onClick);
	}
	
	
	public void HidePopUp()
	{
		followWorldObject.GetComponent<Button>().onClick.RemoveAllListeners();
		
		canvas.enabled = false;
		canvasScaler.enabled = false;
		graphicRaycaster.enabled = false;
	}
	
	
	public void SetFollowTarget(Transform _targetTransform, Vector3 _offset = default)
	{
		followWorldObject.TargetTransform = _targetTransform;
		followWorldObject.Offset = _offset;
	}
}
