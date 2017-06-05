using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {
    public float enemySpeed;

    Animator enemyAnimator;

    //facing
    bool canFlip=true;
    bool facingRight = true;
    float flipTime = 5f;
    float nextFlipChance = 0f;

    //attacking
    public float chargeTime;
    float startChargeTime;
    bool charging;
    bool attack;
    Rigidbody2D enemyRB;


	// Use this for initialization
	void Start () {
        enemyAnimator = GetComponentInChildren<Animator>();
        enemyRB = GetComponentInChildren<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time >nextFlipChance)
        {
            if(Random.Range(0,10)>=5)
            {
                flipFacing();
            }
            nextFlipChance = Time.time + flipTime;
        }
       
	}

void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (facingRight && other.transform.position.x <transform.position.x)
            {
                flipFacing();
            }
            else if(!facingRight && other.transform.position.x>transform.position.x)
            {
                flipFacing();
            }
            if (!enemyAnimator.GetBool("isDeath"))
            {
                canFlip = false;
                charging = true;
                attack = true;
                startChargeTime = Time.time + chargeTime;
            }
            }
      
    }

   void OnTriggerStay2D(Collider2D other)
    {
  
        if (other.tag == "Player" && !enemyAnimator.GetBool("isDeath"))
        {
            if (startChargeTime < Time.time)
            {
                if (!facingRight)
                {
                    enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
                }
                else
                {
                    enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);
                }
                enemyAnimator.SetBool("isCharging", charging);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
 
        if (other.tag == "Player")
        {
            canFlip = true;
            charging = false;
            enemyRB.velocity = new Vector2(-1.0f, 0f);
            enemyAnimator.SetBool("isCharging", charging);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {

        
        if (other.gameObject.tag == "Player" && !enemyAnimator.GetBool("isDeath"))
        {
            enemyAnimator.SetBool("attack", attack);
        }
        if (other.transform.tag == "Abyss")
        {
            GetComponent<EnemyHealth>().makeDead();
        }
    }
    
void OnCollisionExit2D(Collision2D other)
    {
     
        if (other.gameObject.tag == "Player")
        {
            attack = false;
            enemyAnimator.SetBool("attack", attack);
        }
    }
    void flipFacing()
    {
        if(!canFlip)
        {
            return;
        }
        float facingX = transform.localScale.x;
        facingX *= -1f;
        transform.localScale = new Vector3(facingX, transform.localScale.y, transform.localScale.z);
        facingRight = !facingRight;  
    }
}
