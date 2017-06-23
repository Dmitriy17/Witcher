using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour {
    public GameObject loot;

    public void godrop()
    {
        if (loot)
        {
           
            Instantiate(loot, gameObject.transform.position, Quaternion.identity);
        }
    }
}
