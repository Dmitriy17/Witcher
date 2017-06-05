using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenu : MonoBehaviour {
    public AudioSource menuSourse;
    public static SoundMenu instance = null;


    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void PlaySingle4(AudioClip clip)
    {
        menuSourse.clip = clip;
        menuSourse.Play();
    }
    public void Stop(AudioClip clip)
    {
        menuSourse.clip = clip;
        menuSourse.Stop();
    }
}
