using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BgmManager : Singleton<BgmManager>
{
    [Header("BGM")]
    [SerializeField]
    AudioClip[] bgmClips;

    private AudioSource audioSourceBGM;
    private string currentSceneName;
    public static BgmManager instance;

    protected override void Awake()
    {
        
        audioSourceBGM = GetComponent<AudioSource>();

        currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName != "TestMapScene") return;
        base.Awake();
    }

    private void Start()
    {
        if (currentSceneName == "StartScene")
        {
            PlayBGM(0);
        }
        if(currentSceneName == "TestMapScene")
        {
            PlayBGM(1);
        }
    }

    public void PlayBGM(int index)
    {
        audioSourceBGM.clip = bgmClips[index];
        audioSourceBGM.Play();
    }

    public void ChangeBGM(int index)
    {
        audioSourceBGM.Stop();
        audioSourceBGM.clip = bgmClips[index];
        audioSourceBGM.Play();
    }
}
