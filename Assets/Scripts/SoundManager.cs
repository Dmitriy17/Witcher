using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioSource efxSourse;
    public AudioSource playerSourse;
    public AudioSource musicSourse;
    public AudioSource enemySourse;
    public AudioSource weaponsSourse;
    public static SoundManager instance = null;


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

    public void PlaySingle(AudioClip clip)
    {
        efxSourse.clip = clip;
        efxSourse.Play();
    }
    public void Play1(AudioClip clip)
    {
        musicSourse.clip = clip;
        musicSourse.Play();
    }
    public void Stop1(AudioClip clip)
    {
        musicSourse.clip = clip;
        musicSourse.Stop();
    }

    public void RandomizeSfx(params AudioClip [] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        efxSourse.pitch = randomPitch;
        efxSourse.clip = clips[randomIndex];
        efxSourse.Play();
    }

    public void RandomizeSfx1(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        playerSourse.pitch = randomPitch;
        playerSourse.clip = clips[randomIndex];
        playerSourse.Play();
    }

    public void PlaySingle1(AudioClip clip)
    {
        playerSourse.clip = clip;
        playerSourse.Play();
    }

    public void RandomizeSfx2(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        enemySourse.pitch = randomPitch;
        enemySourse.clip = clips[randomIndex];
        enemySourse.Play();
    }
    public void PlaySingle2(AudioClip clip)
    {
        enemySourse.clip = clip;
        enemySourse.Play();
    }
    public void PlaySingle3(AudioClip clip)
    {
        weaponsSourse.clip = clip;
        weaponsSourse.Play();
    }

}
