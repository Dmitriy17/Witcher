using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Call : MonoBehaviour
{

	public float pushBackForce;
    // Use this for initialization
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            pushBack(gameObject.transform);
        }
    }
    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - pushedObject.position.y / 3)).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
