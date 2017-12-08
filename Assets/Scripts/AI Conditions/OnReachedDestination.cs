using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SimpleFSM;
[CreateAssetMenu(menuName = "Condition/AI/OnReachedDestination")]
public class OnReachedDestination : Condition {

    public override bool Decide(StateController controller)
    {
        if(Vector3.Distance(controller.transform.position, controller.GetComponent<NavMeshAgent>().pathEndPosition) < 1f)
        {
            return true;
        }
        return false;
    }

    public override void Reset(StateController controller)
    {
        // nothing
    }

}
