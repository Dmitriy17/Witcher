using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterButton : MonoBehaviour {
    public GameObject Inv;
    private bool Paused;
	// Use this for initialization
	void Awake () {
        Paused = false;
        Inv.SetActive(false);
	}

    private void OnMouseUpAsButton()
    {
        if (!Paused)
        {
            Inv.SetActive(true);
            Time.timeScale = 0f;
            Paused = true;
        }
        else if(Paused)
        {
            Paused = false;
            Inv.SetActive(false);
            Time.timeScale = 1f;
            
        }
    }
}
