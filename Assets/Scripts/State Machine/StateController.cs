using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFSM;
namespace SimpleFSM
{
    public class StateController : MonoBehaviour
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
         
        public void OnSceneGizmo()
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireCube(transform.position, Vector3.one);
        }

    }
}
