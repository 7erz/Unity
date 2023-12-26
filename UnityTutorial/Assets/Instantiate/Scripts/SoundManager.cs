using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   //�ν����Ϳ��� ���� ����
public class Sound
{
    public AudioClip[] audioClips;
}

public class SoundManager: MonoBehaviour
{
    [SerializeField] AudioSource bgmSource;
    [SerializeField] AudioSource sfxSource;

    public static SoundManager instance = null;     //�̱���


    void Awake()
    {
        //�̱���
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
        //unit class ���� ������
        //PlayOneShot() : ���ÿ� ���� ��ġ���� �÷��̵Ǵ� �Լ�
        sfxSource.PlayOneShot(audioClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
