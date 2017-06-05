using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class points : MonoBehaviour {

    // public float pointsAfterDeath;
    [SerializeField]
    public float coeff;

    public float currentVal;
    public float realVal;
    private RageBar rageBar;
    private Rect pos;
    private String text;
    private float posX;
    private float posY;
    private float posWidth;
    private float posHeight;
    private GUIStyle guiStyle = new GUIStyle(); 
        

        // Use this for initialization
    void Start()
    {
        currentVal = 0;
        realVal = 0;
        posX = Screen.width - 69 * 2;
        posY = 10;
        posWidth = 13 + 7 * 6;
        posHeight = 20;
        rageBar = GameObject.Find("rageBox").GetComponent<RageBar>();
        pos.Set(posX, posY, posWidth, posHeight);
    }

    void OnGUI()
    {
        text = Convert.ToString(currentVal);
        float coeff = text.Length - 1;
        pos.Set(posX - coeff * 7, posY, posWidth + coeff * 7, posHeight);
        guiStyle.fontSize = 30;
        guiStyle.normal.textColor = Color.white;
        GUI.Label(pos,"Score:" + text, guiStyle);
    }

    public void addPoints(float val)
    {
        if (rageBar.isRage())
        {
            currentVal = currentVal + coeff * val;
            realVal = realVal + coeff * val;
        }
        else
        {
            currentVal = currentVal +  val;
            realVal = realVal + val;
        }
    }

    public bool usePoints(float val)
    {
        if ((realVal - val) < 0)
            return false;
        else
        {
            realVal -= val;
            return true;
        }
    }
    public float getPoints()
    {
        return currentVal;
    }
    public float getRealPoints()
    {
        return realVal;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
