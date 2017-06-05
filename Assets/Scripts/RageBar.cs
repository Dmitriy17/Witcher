using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageBar : MonoBehaviour {

    [SerializeField]
    private Stat RageStat;
    public float decVar;
    public float rageTime;
    public float decPeriod; 
    public float CoeffOfDamage; 
    public float getPointsAfterDeath; 
    private bool checkOnce = true;
    public GameObject aim;
   // Animator playanim;

    void Start () {
        RageStat.Initialize();
        InvokeRepeating("decrease", 0, decPeriod);
        resetBar();
       // playanim = aim.GetComponent<Animator>();
    }

    public void calculatePoints(float amount)
    {
        if ((RageStat.CurrentValue / RageStat.MaxValue) + (amount / RageStat.MaxValue) <= 0)
        {
            RageStat.CurrentValue = 0.0f;
        }
        else if ((RageStat.CurrentValue / RageStat.MaxValue) + (amount / RageStat.MaxValue) < 1)
        {
            RageStat.CurrentValue += amount;
        }
        else
        {
            if (checkOnce)
            {
                aim.GetComponent<Animator>().SetBool("spinning", true);
                RageStat.CurrentValue = RageStat.MaxValue;
                checkOnce = false;
                InvokeRepeating("resetBar", rageTime, 0);     
            }
        }
    }

    private void resetBar()
    {
        RageStat.CurrentValue = 0.0f;
        checkOnce = true;
        aim.GetComponent<Animator>().SetBool("spinning", false);
    }

    private void decrease()
    {
        if (checkOnce)
        {
            calculatePoints(-decVar);
        }
    }
    public bool isRage()
    {
        return !checkOnce;
    }
    public float getCoeff()
    {
        return CoeffOfDamage;
    }
    public float getPoints()
    {
        return getPointsAfterDeath;
    }
    public void rageUp(float decTimeToActivate, float incCoeff, float incTime)
    {
        rageTime = incTime;
        CoeffOfDamage = incCoeff;
        if (RageStat.MaxValue > 10 && (RageStat.MaxValue - decTimeToActivate) > 0)
            RageStat.MaxValue -= decTimeToActivate;
    }
}
