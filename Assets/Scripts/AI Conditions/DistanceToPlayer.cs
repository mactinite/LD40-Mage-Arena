using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
[CreateAssetMenu(menuName = "Condition/AI/Distance To Player")]
public class DistanceToPlayer : Condition
{
    public float distance = 5;
    public bool greaterThan = false;

    public override bool Decide(Controller controller)
    {
        float playerDistance = Vector3.Distance(controller.transform.position, GameManager.Player.position);
        bool check = greaterThan ? playerDistance >= distance : playerDistance <= distance;
        return check;
    }
}
