using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isVisSkillBox : MonoBehaviour {

    public GameObject points;
    public Canvas skillCanvas;

    private points point;
    // Use this for initialization
    void Start () {
        point = points.GetComponent<points>();
    }
	
	// Update is called once per frame
	void Update () {
        if (point.getRealPoints() >= gameObject.GetComponent<levelOfSkills>().getCost())
            skillCanvas.enabled = true;
        else
            skillCanvas.enabled = false;
    }
}
