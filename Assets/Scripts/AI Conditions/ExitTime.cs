using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SimpleFSM;


[CreateAssetMenu(menuName = "Condition/AI/Exit Time")]
public class ExitTime : Condition {

    public float time = 1;
    float timer = 0;

    bool enterredAction = false;

    public override bool Decide(StateController controller)
    {
        if (!enterredAction)
        {
            enterredAction = true;
            timer = 0;
        }

        timer += Time.deltaTime;
        if (timer > time)
        {
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
        enterredAction = false;
    }
}
