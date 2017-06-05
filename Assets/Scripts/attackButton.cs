using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackButton : MonoBehaviour {

    public GameObject pointsBox;
    public GameObject lvl;

    private points point;
    private levelOfSkills lvlClass;

    private void Start()
    {
        point = pointsBox.GetComponent<points>();
        lvlClass = lvl.GetComponent<levelOfSkills>();
    }
    private void OnMouseUp()
    {
        if(point.usePoints(lvlClass.getCost()))
        {
            lvlClass.AttackLvlUp();
        }
    }
}
