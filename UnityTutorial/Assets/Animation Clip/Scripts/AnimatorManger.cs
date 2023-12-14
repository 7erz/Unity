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
            //�ڷ��� �� ���� var �Ẽ ��
            data.loopTime = false;

            AnimationUtility.SetAnimationClipSettings(animationClips[i], data);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Close"))
        //GetCurrentAnimatorStateInfo(0) - �ִϸ����� ���̾� ������ 0 (Layers)
        //IsName("Close") - ���� Close��� �̸��� ���� �ִϸ�����
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                //���� ������ �ִϸ��̼��� ���� ���¸� �ǹ�
            {
                //������ �������� ����
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
