using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour {

    private void OnMouseUpAsButton()
    {
           if(itemData._itemData.transfer)
        {
            itemData._itemData.tempo = null;
            itemData._itemData.dragTexture = null;
            itemData._itemData.transfer = false;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
