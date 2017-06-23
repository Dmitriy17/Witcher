using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour {

    public item information;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("woeqweqww");
        if (collision.gameObject.tag == "Player")
        {

            if (itemData._itemData.addItem(information))
            {

                Destroy(gameObject);
            }
        }
    }
      

}
