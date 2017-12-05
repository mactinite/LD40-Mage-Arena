using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
namespace FSM
{
    public class Controller : MonoBehaviour
    {
        public State currentState;

        [HideInInspector] public float stateTimeElapsed;


        void Update()
        {
            currentState.UpdateState(this);
        }

        public void TransitionToState(State nextState)
        {
            if(nextState != currentState)
            {
                currentState = nextState;
                
            }
        }

        public bool CheckIfCountDownElapsed(float duration)
        {
            stateTimeElapsed += Time.deltaTime;
            return (stateTimeElapsed >= duration);
        }

        private void OnExitState()
        {
            stateTimeElapsed = 0;
        }

        void OnDrawGizmos()
        {
            if (currentState != null)
            {
                Gizmos.color = currentState.sceneGizmoColor;
                Gizmos.DrawWireSphere(transform.position, 2.0f);
            }
        }
    }
}
