using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClip;
    [SerializeField] AudioSource audioSource;

    public void Search()
    {
        //Drone object 찾기
        GameObject objectSearched = GameObject.Find("Drone");
        //의 자식의 0번째 (바로 밑)의 게임 오브젝트 true 활성화
        objectSearched.transform.GetChild(0).gameObject.SetActive(true);
        //호출할 사운드를 특정한 위치에서 사운드 소리 들리게
        AudioSource.PlayClipAtPoint(audioClip[0], objectSearched.transform.position);
    }

    public void Signal()
    {
        audioSource.PlayOneShot(audioClip[1]);
    }
}
