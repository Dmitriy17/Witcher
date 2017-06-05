using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySnipeDamage : MonoBehaviour
{
    public float damage;
    public float pushBackForce;
    public AudioClip strela;
    float nextDamage;


    // Use this for initialization
    void Start()
    {
        nextDamage = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SoundManager.instance.PlaySingle3(strela);
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            if (other.gameObject.tag == "Player" )
            {
                PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
                thePlayerHealth.addDamage(damage);
                Destroy(gameObject);
                // pushBack(other.transform);
            }
          
        }

    }
    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
