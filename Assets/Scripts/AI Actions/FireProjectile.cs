using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFSM;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Action/AI/FireProjectile")]
public class FireProjectile : Action
{
    public Projectile projectile;
    public float speed = 1000;

    public float accuracy;

    bool init = false;
    bool start = false;
    public override void Act(StateController controller)
    {

        
        if (!start)
        {
            
            controller.GetComponent<NavMeshAgent>().isStopped = true;
            controller.GetComponent<NavMeshAgent>().updatePosition = false;
            controller.GetComponent<NavMeshAgent>().updateRotation = false;
            RotateTowards(controller.transform, GameManager.Player);
            Vector3 origin = controller.transform.position;
            origin.y = controller.transform.position.y + 1f;
            Vector3 target = GameManager.Player.position;
            target.y -= Random.Range(0.25f, 1f);
            CharacterController cc = GameManager.Player.GetComponent<CharacterController>();

            Vector3 direction = (target + cc.velocity) - origin;
            direction.Normalize();
            Projectile obj = Instantiate<Projectile>(projectile, origin, Quaternion.LookRotation(direction));
            obj.speed = speed;
            obj.Fire(direction);
            
            start = true;
        }



        
    }
    public override void Reset(StateController controller)
    {
        controller.GetComponent<NavMeshAgent>().isStopped = false;
        controller.GetComponent<NavMeshAgent>().updatePosition = true;
        controller.GetComponent<NavMeshAgent>().updateRotation = true;
        start = false;
    }


    private void RotateTowards(Transform transform ,Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));    // flattens the vector3
        transform.rotation = lookRotation;
    }

}
