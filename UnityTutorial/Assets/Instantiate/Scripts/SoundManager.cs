using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   //인스펙터에서 볼수 있음
public class Sound
{
    public AudioClip[] audioClips;
}

public class SoundManager: MonoBehaviour
{
    [SerializeField] AudioSource bgmSource;
    [SerializeField] AudioSource sfxSource;

    public static SoundManager instance = null;     //싱글톤


    void Awake()
    {
        //싱글톤
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Sound(AudioClip audioClip)
    {
        //unit class 에서 가져옴
        //PlayOneShot() : 동시에 여러 위치에서 플레이되는 함수
        sfxSource.PlayOneShot(audioClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
