using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClip;
    [SerializeField] AudioSource audioSource;

    public void Search()
    {
        //Drone object ã��
        GameObject objectSearched = GameObject.Find("Drone");
        //�� �ڽ��� 0��° (�ٷ� ��)�� ���� ������Ʈ true Ȱ��ȭ
        objectSearched.transform.GetChild(0).gameObject.SetActive(true);
        //ȣ���� ���带 Ư���� ��ġ���� ���� �Ҹ� �鸮��
        AudioSource.PlayClipAtPoint(audioClip[0], objectSearched.transform.position);
    }

    public void Signal()
    {
        audioSource.PlayOneShot(audioClip[1]);
    }
}
