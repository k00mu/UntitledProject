// ==================================================
// 
//   Created by atqamz
// 
// ==================================================

using UnityEngine;
using UnityEngine.UI;

public class FollowWorldObject : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private Transform targetTransform;
	[SerializeField] private Button button;
	public Button Button => button;
	public Transform TargetTransform { set => targetTransform = value; }
	
	[Header("Settings")]
	[SerializeField] private Vector3 offset;
	public Vector3 Offset { set => offset = value; }
	
	private Camera mainCamera;


	private void OnEnable()
	{
		mainCamera = Camera.main;
	}
	
	
	private void Update()
	{
		FollowTargetPosition();
	}


	private void FollowTargetPosition()
	{
		if (targetTransform == null) { return; }
		Vector3 targetPosition = mainCamera.WorldToScreenPoint(targetTransform.position + offset);
		if (transform.position == targetPosition) { return; }
		transform.position = targetPosition;
	}
}
