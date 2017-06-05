﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    [SerializeField]
    internal Stat healthPlayer;
    [SerializeField]
    private Text healthText;
    public AudioClip hit4;
    public AudioClip hit5;
    public AudioClip death;
    public AudioClip d;
    private bool onCD;
    Animator anim;
    PlayerController controlMovement;


    // Use this for initialization
    void Start() {
        healthPlayer.Initialize();
        healthText.text = healthPlayer.CurrentValue.ToString();
        controlMovement = GetComponent<PlayerController>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

    }
    public void addDamage(float damage)
    {
        if(damage <=0)
        {
            return;
        }
        if (!onCD)
        {
            StartCoroutine(Damage());
            CombatTextManager.CombatTM.CreatText(transform.position, damage.ToString(), Color.white);
            healthPlayer.CurrentValue -= damage;
            healthText.text = healthPlayer.CurrentValue.ToString();
            print(healthPlayer.CurrentValue);
            SoundManager.instance.RandomizeSfx1(hit4, hit5);
            if (healthPlayer.CurrentValue <= 0)
            {
                makeDeath();
            }
        }
    }
    private IEnumerator Damage()
    {
        onCD = true;
        yield return new WaitForSeconds(1);
        onCD = false;
    }
    public void makeDeath()
    {
        SoundManager.instance.PlaySingle1(death);
        anim.SetBool("death", true);
        InvokeRepeating("loadDeathmenu", 1.5f, 0);
        Destroy(gameObject,1.5f);   
    }
    private void loadDeathmenu()
    {
        SceneManager.LoadScene(2);
        SoundManager.instance.Stop1(d);
    }
    public void healthUp(float incHealth)
    {
        healthPlayer.MaxValue += incHealth - healthPlayer.MaxValue;
        healthPlayer.CurrentValue = healthPlayer.MaxValue;
        healthText.text = healthPlayer.CurrentValue.ToString();
    }
}
