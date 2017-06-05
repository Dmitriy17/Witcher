using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    [SerializeField]
    private Stat healthEnemy;
    public AudioClip death;
    public AudioClip hit1;
    public AudioClip hit2;
    float tempo;
    Animator anim;
    private bool Dead = true;
    public float pointsAfterDeath;

    void Start () {
        healthEnemy.Initialize();
        anim = GetComponent<Animator>();
    }
	
    public void addDamage(float damage)
    {
        if (Dead)
        {
            SoundManager.instance.RandomizeSfx2(hit1, hit2);
            CombatTextManager.CombatTM.CreatText(GetComponent<CircleCollider2D>().transform.position, damage.ToString(), Color.white);
            healthEnemy.CurrentValue -= damage;
        }
        if (healthEnemy.CurrentValue <= 0)
        {
            SoundManager.instance.PlaySingle2(death);
            makeDead();
        }
    }
    public void makeDead()
    {
        if (Dead)
        {
            anim.SetBool("isDeath", true);
            anim.SetBool("isCharging", false);
            anim.SetBool("attack", false);
            Destroy(gameObject, 1.7f);
            RageBar rageBox = GameObject.Find("rageBox").GetComponent<RageBar>();
            points pointsBox = GameObject.Find("points").GetComponent<points>();
            pointsBox.addPoints(pointsAfterDeath);
            rageBox.calculatePoints(rageBox.getPoints());
            Dead = false;
        }
    }
}

