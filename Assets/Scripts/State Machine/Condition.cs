using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FSM
{
    public abstract class Condition : ScriptableObject
    {
        public abstract bool Decide(Controller controller);
    }
}
