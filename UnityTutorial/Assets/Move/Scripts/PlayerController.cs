using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 dir;
    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        //Input.GetAxis() : Ư���� key�� ���� �� -1 ~ 1 ������ ���� ��ȯ�ϴ� �Լ�
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        //������ ����ȭ
        dir.Normalize();

        //Time.deltaTime : ���� �������� �Ϸ�Ǵ� �� ���� �ɸ� �ð� �ǹ�
        Debug.Log(Time.deltaTime);
        transform.position += dir * speed * Time.deltaTime;
    }
}
