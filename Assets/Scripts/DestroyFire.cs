using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFire : MonoBehaviour {

    public float alivetime;
	// Use this for initialization
	void Awake  () {
        Destroy(gameObject, alivetime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
