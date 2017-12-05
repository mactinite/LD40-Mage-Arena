using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FSM;
[CreateAssetMenu(menuName = "Action/AI/FollowPlayer")]
public class FollowPlayer : Action {

    public override void Act(Controller controller)
    {
        controller.GetComponent<NavMeshAgent>().isStopped = false;

        NavMeshAgent agent = controller.GetComponent<NavMeshAgent>();
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        if (playerPos != agent.destination)
            agent.SetDestination(playerPos);
    }
}
