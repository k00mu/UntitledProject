// ==================================================
// 
//   Created by atqamz
// 
// ==================================================

using UnityEngine;
using UnityEngine.UI;

public class CanvasWrapper : MonoBehaviour
{
	[Header("CanvasWrapper References")]
	[SerializeField] private Canvas canvas;
	[SerializeField] private CanvasScaler canvasScaler;
	[SerializeField] private GraphicRaycaster graphicRaycaster;
	
	
	
	protected void EnableCanvas()
	{
		canvas.enabled = true;
		canvasScaler.enabled = true;
		graphicRaycaster.enabled = true;
	}
	
	
	protected void DisableCanvas()
	{
		canvas.enabled = false;
		canvasScaler.enabled = false;
		graphicRaycaster.enabled = false;
	}
}
