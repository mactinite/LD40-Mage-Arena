using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFSM;
namespace SimpleFSM
{
    public class StateController : MonoBehaviour
    {
        public State currentState;

        private void Start()
        {
            ResetTransitions();
            ResetActions();
        }

        void Update()
        {
            currentState.UpdateState(this);
        }

        public void TransitionToState(State nextState)
        {
            if(nextState != currentState && nextState != null)
            {
                ResetActions();
                ResetTransitions();
                currentState = nextState;
                ResetActions();
                ResetTransitions();
            }
        }
         
        public void OnSceneGizmo()
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireCube(transform.position, Vector3.one);
        }


        void ResetActions()
        {
            foreach(Action action in currentState.actions)
            {
                action.Reset(this);
            }
        }

        void ResetTransitions()
        {
            foreach(Transition transition in currentState.transitions)
            {
                transition.ResetConditions(this);
            }
        }

    }
}
