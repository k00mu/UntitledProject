// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private NavMeshAgent navMeshAgent;
	
	
	
	private void OnEnable()
	{
		PlaySpace.Instance.OnClick += OnPlaySpaceClick;
	}

	private void OnDisable()
	{
		PlaySpace.Instance.OnClick -= OnPlaySpaceClick;
	}


	/// <summary>
	/// Handles the click event on the play space.
	/// </summary>
	/// <param name="_position">The position where the click occurred.</param>
	private void OnPlaySpaceClick(Vector3 _position)
	{
		Debug.Log($"[PlayerController] Clicked at: {_position}");
		
		SetPlayerDestination(_position);
	}
	
	
	/// <summary>
	/// Sets the destination of the player to the specified position.
	/// </summary>
	/// <param name="_position">The position to set as the destination.</param>
	private void SetPlayerDestination(Vector3 _position)
	{
		navMeshAgent.SetDestination(_position);
	}
}
