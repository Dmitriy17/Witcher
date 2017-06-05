using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct statsRageButton
{
    public int currentLvl;
    public float incTime;
    public float incCoeff;
    public float decTimeToActivate;
};
struct statsAttackButton
{
    public int currentLvl;
    public float incDamage;
};
struct statsHealthButton
{
    public int currentLvl;
    public float incHealth;
};

struct stats
{ 
    public statsRageButton rage;
    public statsAttackButton attack;
    public statsHealthButton health;
};

public class levelOfSkills : MonoBehaviour {
    [SerializeField]
    public GameObject aim;
    public GameObject rageBox;
    public int countsLevels;
    public float howMuchCostOneLvl;

    public float incTime1lvl;
    public float incCoeff1lvl;
    public float decTimeToActivate1lvl;
    public float incDamage1lvl;
    public float incHealth1lvl;

    private stats statsOfLevel;
    private RageBar rage;
    private PlayerHealth health;

    // Use this for initialization
    void Start ()
    {
        statsOfLevel.attack.currentLvl = 1;
        statsOfLevel.attack.incDamage = incDamage1lvl;
        statsOfLevel.rage.currentLvl = 1;
        statsOfLevel.rage.decTimeToActivate = decTimeToActivate1lvl;
        statsOfLevel.rage.incCoeff = incCoeff1lvl;
        statsOfLevel.rage.incTime = incTime1lvl;
        statsOfLevel.health.currentLvl = 1;
        statsOfLevel.health.incHealth = incHealth1lvl;

        rage = rageBox.GetComponent<RageBar>();
        health = aim.GetComponent<PlayerHealth>();

        statsOfLevel.health.incHealth += 10;
    }

    public void RageLvlUp()
    {
        statsOfLevel.rage.currentLvl += 1;
        statsOfLevel.rage.decTimeToActivate += 3;
        statsOfLevel.rage.incCoeff++;
        statsOfLevel.rage.incTime += 5;
        rage.rageUp(statsOfLevel.rage.decTimeToActivate, statsOfLevel.rage.incCoeff, statsOfLevel.rage.incTime);
    }
    public void AttackLvlUp()
    {
        statsOfLevel.attack.currentLvl += 1;
        statsOfLevel.attack.incDamage += 5;
    }
    public void HealthLvlUp()
    {
        if (health.healthPlayer.MaxValue == health.healthPlayer.CurrentValue)
        {
            statsOfLevel.health.currentLvl += 1;
            statsOfLevel.health.incHealth += 10;
            health.healthUp(statsOfLevel.health.incHealth);
        }
        else
        {
            health.healthUp(health.healthPlayer.MaxValue);
        }
    }
    public int getCurLvlRage()
    {
        return statsOfLevel.rage.currentLvl;
    }
    public int getCurLvlAttack()
    {
        return statsOfLevel.attack.currentLvl;
    }
    public int getCurLvlHealth()
    {
        return statsOfLevel.health .currentLvl;
    }
    public int getMaxLvl()
    {
        return countsLevels;
    }
    public float lvlDmg()
    {
        return statsOfLevel.attack.incDamage;
    }
    public float getCost()
    {
        return howMuchCostOneLvl;
    }
}