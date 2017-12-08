using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFSM;
using UnityEngine.AI;
[CreateAssetMenu(menuName = "Action/AI/NavToRandomPointNearPlayer")]
public class NavToRandomPointNearPlayer : Action
{
    public float distance = 25;
    public float innerRadius = 2f;
    public float outerRadius = 5f;

    Vector3 RandomPoint;
    NavMeshAgent agent;


    bool init = false;
    public override void Act(StateController controller)
    {
        agent.isStopped = false;
        if (!init)
            Init(controller);
        Debug.DrawLine(controller.transform.position, RandomPoint);
        Debug.DrawLine(GameManager.Player.position, RandomPoint);
        if (Vector3.Distance(RandomPoint, controller.transform.position) < 1)
        {
            init = false;
        }

    }

    public override void Reset(StateController controller)
    {
        init = false;
    }

    void Init(StateController controller )
    {
        agent.isStopped = false;
        RandomPoint = GetRandomPositionInTorus(innerRadius, outerRadius);
        RandomPoint += GameManager.Player.position;


        agent = controller.GetComponent<NavMeshAgent>();
        NavMeshHit hit;
        NavMesh.SamplePosition(RandomPoint, out hit, 25f, NavMesh.AllAreas);
        RandomPoint = hit.position;
        agent.SetDestination(hit.position);
        
        init = true;

    }

    Vector3 GetRandomPositionInTorus(float ringRadius, float wallRadius)
    {
        // get a random angle around the ring
        float rndAngle = Random.value * 6.28f; // use radians, saves converting degrees to radians

        // determine position
        float cX = Mathf.Sin(rndAngle);
        float cZ = Mathf.Cos(rndAngle);

        Vector3 ringPos = new Vector3(cX, 0, cZ);
        ringPos *= ringRadius;

        // At any point around the center of the ring
        // a sphere of radius the same as the wallRadius will fit exactly into the torus.
        // Simply get a random point in a sphere of radius wallRadius,
        // then add that to the random center point
        Vector3 sPos = Random.insideUnitSphere * wallRadius;

        return (ringPos + sPos);
    }

}
