using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SimpleFSM
{
    [CreateAssetMenu(menuName = "New State")]
    public class State : ScriptableObject
    {
        public Action[] actions;
        public Transition[] transitions;
        public Color sceneGizmoColor = Color.grey;

        public void UpdateState(StateController controller)
        {
            DoActions(controller);
            CheckTransitions(controller);
        }

        public void DoActions(StateController controller)
        {
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].Act(controller);
            }
        }

        public void CheckTransitions(StateController controller)
        {
            for (int i = 0; i < transitions.Length; i++)
            {
                // OR all different transitions.
                if (transitions[i].DoTransition(controller) != null)
                {
                    State transitionTo = transitions[i].DoTransition(controller);
                    controller.TransitionToState(transitionTo);
                    return;
                }

            }

        }
    }



}
