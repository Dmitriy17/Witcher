using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDeath : MonoBehaviour {
    Animation playanim;

    // Use this for initialization
    void Start () {
        playanim = GetComponent<Animation>();
    }
	public void Death()
    {
        playanim.Play();
    }
}
