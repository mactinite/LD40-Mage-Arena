using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FSM;
[CreateAssetMenu(menuName = "Condition/AI/Stop For Seconds")]
public class StopForSeconds : Condition {

    public float time = 1;
    float timer = 0;

    bool enterredAction = false;

    public override bool Decide(Controller controller)
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
            return true;
        }
        else
        {
            return false;
        }
    }
}
