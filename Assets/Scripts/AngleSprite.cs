using UnityEngine;
[SelectionBase]
public class AngleSprite : MonoBehaviour
{
    public Transform toFace;
    private Animator anim;
    private float theta;
    private Vector3 a;
       
    
    void Update()
    {
        anim = GetComponentInChildren<Animator>();
        anim.SetFloat("PlayerDirection", GetAngleIndex());
    }
    float GetAngleIndex()
    {
        Vector3 a = transform.forward;
        Vector3 b = anim.transform.forward;
        a.Normalize();
        b.Normalize();

        float angle = Vector3.SignedAngle(a, b, transform.up);

        angle += 180;

        return angle;

    }

}