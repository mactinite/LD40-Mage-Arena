using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FSM
{
    [CreateAssetMenu(menuName = "New State")]
    public class State : ScriptableObject
    {
        public Action[] actions;
        public Transition[] transitions;
        public Color sceneGizmoColor = Color.grey;

        public void UpdateState(Controller controller)
        {
            DoActions(controller);
            CheckTransitions(controller);
        }

        public void DoActions(Controller controller)
        {
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].Act(controller);
            }
        }

        public void CheckTransitions(Controller controller)
        {
            for (int i = 0; i < transitions.Length; i++)
            {
                bool decisionSucceeded = transitions[i].condition.Decide(controller);

                if (decisionSucceeded)
                {
                    controller.TransitionToState(transitions[i].trueState);
                }
                else
                {
                    controller.TransitionToState(transitions[i].falseState);
                }
            }
        }
    }



}
