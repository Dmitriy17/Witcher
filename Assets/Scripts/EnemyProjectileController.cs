using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileController : MonoBehaviour {

    public float fireSpeed;

    private GameObject Target;
    private float angle;
    Rigidbody2D myRB;
    

    // Use this for initialization
    void Awake()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        angle = Vector2.Angle(Target.transform.position, gameObject.transform.position);
        
        myRB = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 180+angle);
            myRB.AddForce(new Vector2( Target.transform.position.x-3, Target.transform.position.y)* fireSpeed, ForceMode2D.Force);
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 0, -angle);
            myRB.AddForce(new Vector2(Target.transform.position.x+3, Target.transform.position.y) * fireSpeed, ForceMode2D.Force);

        }
    }
}
