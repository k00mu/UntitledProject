// ==================================================
// 
//   Created by atqamz
// 
// ==================================================

using UnityEngine;

public class FaceToCamera : MonoBehaviour
{
	private Camera targetCamera;

	private void Start()
	{
		targetCamera = Camera.main;
	}

	private void Update()
	{
		transform.forward = targetCamera.transform.forward;
	}
}
