using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SimpleFSM
{
    [System.Serializable]
    public class Transition
    {
        public Condition[] conditions;
        public State trueState;
        public State falseState;


        public bool GetTransitionValue(StateController controller)
        {
            bool isPassed = true;
            // AND all different conditions.
            foreach (Condition condition in conditions)
            {
                if (!condition.Decide(controller))
                {
                    isPassed = false; // If any condition fails, the transition falls to the falseState
                }
            }

            return isPassed;
        }

        public State DoTransition(StateController controller)
        {
            bool isPassed = true;
            // AND all different conditions.
            foreach (Condition condition in conditions)
            {
                if (!condition.Decide(controller))
                {
                    isPassed = false; // If any condition fails, the transition falls to the falseState
                }
            }

            return isPassed ? trueState : falseState;
        }

    }
}
