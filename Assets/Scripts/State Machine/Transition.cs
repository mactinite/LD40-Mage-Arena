using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FSM
{
    [System.Serializable]
    public class Transition
    {
        public Condition condition;
        public State trueState;
        public State falseState;
    }
}
