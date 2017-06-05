using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {

    public float fireSpeed;
    Rigidbody2D myRB;
    public AudioClip fireball;


	// Use this for initialization
	void Awake () {
        SoundManager.instance.PlaySingle(fireball);
        myRB = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
        {
          
            myRB.AddForce(new Vector2(-1, 0) * fireSpeed, ForceMode2D.Force);
        }
        else
        {
            myRB.AddForce(new Vector2(1, 0) * fireSpeed, ForceMode2D.Force);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void removeForce()
    {
        myRB.velocity = new Vector2(0, 0);
    }
}
