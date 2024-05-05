// // ==================================================
// //
// //   Created by Atqa Munzir
// //
// // ==================================================

using UnityEngine;
using UnityEngine.AI;

namespace UntitledProject.Scripts
{
    public class PlayerController
    {
        [SerializeField] private NavMeshAgent _agent;



        private void Update()
        {
            if (Input.touchCount > 0) 
                TouchInput();
            
            if (Input.GetMouseButtonDown(0))
                MouseInput();
        }

        private void TouchInput()
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase != TouchPhase.Ended) 
                    continue;

                Vector3 touchPosition = WorldPointer.GetPosition(touch.fingerId);
                if (touchPosition != Vector3.zero) 
                    SetPlayerDestination(touchPosition);
            }
        }
        
        private void MouseInput()
        {
            Vector3 mousePosition = WorldPointer.GetPosition();
            if (mousePosition != Vector3.zero) 
                SetPlayerDestination(mousePosition);
        }
        
        private void SetPlayerDestination(Vector3 position)
        {
            _agent.SetDestination(position);
        }
    }
}