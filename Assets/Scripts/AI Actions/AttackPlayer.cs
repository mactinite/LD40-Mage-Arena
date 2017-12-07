using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SimpleFSM;

[CreateAssetMenu(menuName = "Action/AI/AttackPlayer")]
public class AttackPlayer : Action {

    public int damage = 5;
        
    public override void Act(StateController controller)
    {
        controller.GetComponent<NavMeshAgent>().isStopped = true ;

        PlayerHealth player = GameManager.Player.GetComponent<PlayerHealth>();
        //Play attack effect or animation 
        player.Damage(damage);

    }
}
