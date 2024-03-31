// ==================================================
// 
//   Created by Atqa Munzir
// 
// ==================================================

using UnityEngine;

public class GameManager : MonoBehaviourSingletonDDOL<GameManager>
{
	[SerializeField] private PlaySpace activePlaySpace;
	public PlaySpace ActivePlaySpace => activePlaySpace;
	
	
	
	public void SetActivePlaySpace(PlaySpace _playSpace)
	{
		activePlaySpace = _playSpace;
		// enable the new play space
	}
}
