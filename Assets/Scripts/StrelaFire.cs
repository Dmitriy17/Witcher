using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrelaFire : MonoBehaviour
{

    public float fireSpeed1;
    Rigidbody2D myRB1;


    // Use this for initialization
    void Awake()
    {
        myRB1 = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
        {

            myRB1.AddForce(new Vector2(-1, 0) * fireSpeed1, ForceMode2D.Force);
        }
        else
        {
            myRB1.AddForce(new Vector2(1, 0) * fireSpeed1, ForceMode2D.Force);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void removeForce()
    {
        myRB1.velocity = new Vector2(0, 0);
    }
}
