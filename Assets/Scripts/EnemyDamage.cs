using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    public float damage;
    public float damageRate;
    public float pushBackForce;
    public AudioClip hit;

    float nextDamage;

	// Use this for initialization
	void Start () {
        nextDamage = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player" && nextDamage<Time.time)
        {
            PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
            thePlayerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;
            SoundManager.instance.PlaySingle3(hit);

            // pushBack(other.transform);
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
