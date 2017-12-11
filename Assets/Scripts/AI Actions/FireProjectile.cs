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
    public float delayShot = 1f;

    Projectile proj;
    public float accuracy;
    float timer = 0;
    bool fired = false;
    bool start = false;
    public override void Act(StateController controller)
    {
        
        if (!start)
        {
            timer = 0;
            controller.GetComponent<NavMeshAgent>().isStopped = true;
            controller.GetComponent<NavMeshAgent>().updatePosition = false;
            controller.GetComponent<NavMeshAgent>().updateRotation = false;
            RotateTowards(controller.transform, GameManager.Player);

            Vector3 origin = controller.transform.position;
            origin.y = controller.transform.position.y + 1f;
            Vector3 target = GameManager.Player.position;
            CharacterController cc = GameManager.Player.GetComponent<CharacterController>();
            Vector3 direction = (target + cc.velocity) - origin;

            proj = Instantiate<Projectile>(projectile, origin, Quaternion.LookRotation(direction));

            
            start = true;
        }
        timer += Time.deltaTime;
        if (start && timer > delayShot && !fired)
        {
            Vector3 origin = controller.transform.position;
            origin.y = controller.transform.position.y + 1f;
            Vector3 target = GameManager.Player.position;
            target.y -= Random.Range(0.25f, 1f);
            CharacterController cc = GameManager.Player.GetComponent<CharacterController>();
            Vector3 direction = (target + cc.velocity) - origin;
            direction.Normalize();
            proj.speed = speed;
            proj.Fire(direction);
            fired = true;
            timer = 0;
        }


        
    }
    public override void Reset(StateController controller)
    {
        proj = null;
        controller.GetComponent<NavMeshAgent>().isStopped = false;
        controller.GetComponent<NavMeshAgent>().updatePosition = true;
        controller.GetComponent<NavMeshAgent>().updateRotation = true;
        start = false;
        fired = false;
        timer = 0;
    }


    private void RotateTowards(Transform transform ,Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));    // flattens the vector3
        Debug.Log(direction);
        Debug.DrawRay(transform.position, direction * 5);
        transform.rotation = lookRotation;

    }

}
