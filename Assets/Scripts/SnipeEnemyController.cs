using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnipeEnemyController : MonoBehaviour
{

    Animator enemyAnimator;
    //facing
    bool canFlip = true;
    bool facingRight = true;
    float flipTime = 5f;
    float nextFlipChance = 0f;

    //attacking
    public float chargeTime;
    float startChargeTime;
    bool attack;
    Rigidbody2D enemyRB;
    public Transform fireTip;
    public GameObject fire;
    float fireRate = 0.5f;
    float nextFire = 0f;
    // Use this for initialization
    void Start()
    {
        enemyAnimator = GetComponentInChildren<Animator>();
        enemyRB = GetComponentInChildren<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFlipChance)
        {
            if (Random.Range(0, 10) >= 5)
            {
                flipFacing();
            }
            nextFlipChance = Time.time + flipTime;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (facingRight && other.transform.position.x < transform.position.x)
            {
                flipFacing();
            }
            else if (!facingRight && other.transform.position.x > transform.position.x)
            {
                flipFacing();
            }
            if (!enemyAnimator.GetBool("isDeath"))
            {
                canFlip = false;
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
                enemyAnimator.SetBool("attack", attack);
                gofire();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            canFlip = true;
            enemyRB.velocity = new Vector2(-1.0f, 0f);
            attack = false;
            enemyAnimator.SetBool("attack", attack);
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

    void flipFacing()
    {
        if (!canFlip)
        {
            return;
        }
        float facingX = transform.localScale.x;
        facingX *= -1f;
        transform.localScale = new Vector3(facingX, transform.localScale.y, transform.localScale.z);
        facingRight = !facingRight;
    }
    void gofire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(fire, fireTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!facingRight)
            {
                Instantiate(fire, fireTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }

    }
}

