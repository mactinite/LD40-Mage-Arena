using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SimpleFSM;
[CreateAssetMenu(menuName = "Condition/AI/Stop For Seconds")]
public class StopForSeconds : Condition {

    public float time = 1;
    float timer = 0;

    bool enterredAction = false;

    public override bool Decide(StateController controller)
    {
        if (!enterredAction)
        {
            controller.GetComponent<NavMeshAgent>().isStopped = true;
            enterredAction = true;
            timer = 0;
        }

        timer += Time.deltaTime;
        if (timer > time)
        {
            enterredAction = false;
            timer = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void Reset(StateController controller)
    {
        timer = 0;
        controller.GetComponent<NavMeshAgent>().isStopped = false;
        enterredAction = false;
    }

}
