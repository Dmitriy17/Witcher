using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public float weaponDamage;
    Animator fireanim;
    projectileController myPC;

    void Awake()
    {
        myPC = GetComponentInParent<projectileController>();
         fireanim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable") || other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if(other.tag != "Player")
            { 
            myPC.removeForce();
            fireanim.SetBool("destroy", true);
            if(other.tag =="Enemy")
            {
                EnemyHealth hurtHealth = other.gameObject.GetComponent<EnemyHealth>();
                RageBar rageBox = GameObject.Find("rageBox").GetComponent<RageBar>();
                levelOfSkills lvl = GameObject.Find("playerLvl").GetComponent<levelOfSkills>();
                if (rageBox.isRage())
                    hurtHealth.addDamage(rageBox.getCoeff() * weaponDamage + lvl.lvlDmg());
                else
                    hurtHealth.addDamage(weaponDamage + lvl.lvlDmg());
            }
        }
        }
    }
}
