using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : Singleton<SfxManager>
{
    [Header("SFX")]
    [SerializeField] AudioClip[] sfxClips;

    private AudioSource audioSourceSFX;

    protected override void Awake()
    {
        base.Awake();
        audioSourceSFX = GetComponent<AudioSource>();
    }

    public void PlayEatSound()
    {
        audioSourceSFX.clip = sfxClips[0];
        audioSourceSFX.Play();
    }

    public void PlayJumpSound()
    {
        audioSourceSFX.clip = sfxClips[1];
        audioSourceSFX.Play();
    }

    public void PlayDoubleJumpSound()
    {
        audioSourceSFX.clip = sfxClips[2];
        audioSourceSFX.Play();
    }
}
