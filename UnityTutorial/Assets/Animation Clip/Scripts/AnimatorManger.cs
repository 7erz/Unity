using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AnimatorManger : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip[] animationClips;
    void Start()
    {
        for(int i =0; i< animationClips.Length; i++)
        {
            var data = AnimationUtility.GetAnimationClipSettings(animationClips[i]);
            //자료형 모를 때는 var 써볼 것
            data.loopTime = false;

            AnimationUtility.SetAnimationClipSettings(animationClips[i], data);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Close"))
        //GetCurrentAnimatorStateInfo(0) - 애니메이터 레이어 순서가 0 (Layers)
        //IsName("Close") - 에서 Close라고 이름이 적힌 애니메이터
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                //현재 진행한 애니메이션의 실행 상태를 의미
            {
                //실행이 끝났으니 끄기
                animator.gameObject.SetActive(false);
            }
        }
    }
    public void Open()
    {
        animator.gameObject.SetActive(true);
    }
    public void Close()
    {
        animator.SetTrigger("Close");
    }
}
