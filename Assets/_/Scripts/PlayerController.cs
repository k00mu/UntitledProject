// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using System;
using UnityEngine;
using UnityEngine.AI;

namespace __Scripts
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private NavMeshAgent navMeshAgent;



		private void OnEnable()
		{
			GameManager.Instance.ActivePlaySpace.OnClick += ActivePlaySpace_OnClick;
		}

		private void OnDisable()
		{
			GameManager.Instance.ActivePlaySpace.OnClick -= ActivePlaySpace_OnClick;
		}


		/// <summary>
		/// Handles the click event on the play space.
		/// </summary>
		/// <param name="_position">The position where the click occurred.</param>
		private void ActivePlaySpace_OnClick(Vector3 _position)
		{
			LogHelper.Log(nameof(PlayerController), nameof(ActivePlaySpace_OnClick), $"Clicked at: {_position}");
			if (_position == Vector3.zero)
			{
				return;
			}

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
}
