using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private Vector3 positionA;
    private Vector3 positionB;
    private Vector3 nextPosition;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform childTransform;
    [SerializeField]
    private Transform transformB;
    // Use this for initialization
    void Start ()
    {
        positionA = childTransform.localPosition;
        positionB = transformB.localPosition;

        nextPosition = positionB;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
    }

    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPosition, speed * Time.deltaTime);
        if (Vector3.Distance(childTransform.localPosition, nextPosition) == 0.0)
        {
            ChangeDestination();
        } 
    }

    private void ChangeDestination()
    {
        nextPosition = nextPosition != positionA ? positionA : positionB; 
    }

}
