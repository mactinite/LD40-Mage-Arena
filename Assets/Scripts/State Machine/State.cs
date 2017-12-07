using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SimpleFSM
{
    [CreateAssetMenu(menuName = "New State")]
    public class State : ScriptableObject
    {
        public Action[] actions;
        public List<Transition> transitions = new List<Transition>();
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
            for (int i = 0; i < transitions.Count; i++)
            {
                State transitionTo = transitions[i].DoTransition(controller);
                // OR all different transitions.
                if (transitionTo != null)
                {
                    controller.TransitionToState(transitionTo);
                    return;
                }

            }

        }

        public override string ToString()
        {
            return this.name;
        }

    }



}
