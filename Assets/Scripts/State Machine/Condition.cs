using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SimpleFSM
{
    public abstract class Condition : ScriptableObject
    {
        public abstract bool Decide(StateController controller);
        public abstract void Reset(StateController controller);
    }
}
