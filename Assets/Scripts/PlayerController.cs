using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float maxspeed = 11f;
    bool right = true;
    Animator playanim;
    bool ground = false;
    public Transform grCheck;
    float grRadius = 0.2f;
    public float jForce = 1000f;
    public LayerMask wiGround;
    public AudioClip d;
    public AudioClip f;

    private RageBar rage;
    //for shooting
    public Transform fireTip;
    public GameObject fire;
    float fireRate = 0.5f;
    float nextFire = 0f;
    private bool checkForTab = true;
    public int countmana;
    private PlayerHealth playerhealth;
    void Start () {
        playerhealth = gameObject.GetComponent<PlayerHealth>();
       playanim = GetComponent<Animator>();

    }
    private void Update()
    {
        if (ground && CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            playanim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jForce));
        }
        //player shooting
        if( Input.GetAxis("Fire1")>0 )
        {
                gofire_1();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ground = Physics2D.OverlapCircle(grCheck.position, grRadius, wiGround);
        playanim.SetBool("Ground", ground);
        playanim.SetFloat("VertSpeed", GetComponent<Rigidbody2D>().velocity.y);
        float  move = CrossPlatformInputManager.GetAxis("Horizontal");
        playanim.SetFloat("speed", Mathf.Abs(move));
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxspeed, GetComponent<Rigidbody2D>().velocity.y);
        if (move > 0 && !right)
        {
            Flip();
        }
        if (move < 0 && right)
        {
            Flip();
        }
    }
    private void Flip()
    {
        right = !right;
        Vector3 scale = transform.localScale;
        scale.x = scale.x * (-1);
        transform.localScale = scale;
    }
    void gofire_1()
    {
        if (Time.time > nextFire)
        {
            if (playerhealth.takeMana(countmana))
            {


                nextFire = Time.time + fireRate;
                if (right)
                {
                    Instantiate(fire, fireTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                }
                else if (!right)
                {
                    Instantiate(fire, fireTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
                }

            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "MovingPlatform" && (transform.localPosition.y - 1.5) > collision.transform.localPosition.y)
        {
            transform.parent = collision.transform;
        }
        else if (collision.transform.tag == "Abyss" )
        {
            GetComponent<PlayerHealth>().makeDeath();
        }
        else if (collision.transform.tag == "Broom")
        {
            InvokeRepeating("loadWinmenu", 1f, 0);
        }
    }


private void loadWinmenu()
{
        SceneManager.LoadScene(3);
        SoundManager.instance.Stop1(d);
        SoundWin.instance.PlaySingle4(f);
    }

private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
}