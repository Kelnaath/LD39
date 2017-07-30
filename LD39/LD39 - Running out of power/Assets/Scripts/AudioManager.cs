using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : AbstractTimeTick {

    public static AudioManager instance;

    public AudioClip pickup;
    public AudioClip hitBarricade;
    public AudioClip destroyBarricade;

    public List<AudioClip> zombies;

    public AudioSource audioSource;
    public AudioSource zombieSource;

    private int soundTick = 2;

    public enum AudioClips
    {
        PICKUP,
        HIT,
        DESTROY
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();		
	}

    public void PlayAudioClip(AudioClips clip)
    {
        switch (clip)
        {
            case AudioClips.PICKUP:
                audioSource.PlayOneShot(pickup);
                break;
            case AudioClips.HIT:
                audioSource.PlayOneShot(hitBarricade);
                break;
            case AudioClips.DESTROY:
                audioSource.PlayOneShot(destroyBarricade);
                break;
        }
    }

    public void PlayZombies()
    {
        zombieSource.PlayOneShot(zombies[UnityEngine.Random.Range(0, zombies.Count)]);
        //zombieSource.PlayOneShot(hitBarricade);
    }

    public override void UpdateTick()
    {
        soundTick--;
        if (GameplayManager.instance.distanceFromHorde < 300f && soundTick <= 0)
        {
            soundTick = 2;
            PlayZombies();
        }
            
    }
}
