using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Vector3 dir;
    [SerializeField] float speed;


    private void Awake()
    {
        //������ ���� �� �� ���� ������Ʈ�� �̸��� �˻���.
        target = GameObject.Find("Player");
    }
    //���� ��
    /*
    private void Start()
    {
        //lookAt() : Ư���� ����� �ٶ󺸴� �Լ�
        //transform.LookAt(target.transform);
    }

    private void Update()
    {
        transform.LookAt(target.transform);
        transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, 10f * Time.deltaTime);
    }*/

    //�߻�ȭ ������ �� �ܺο��� ���� ���ؼ� abstract ���
    public void Update()
    {
        Move();
    }
    public virtual void Move()
    {
        /*
        //1. Target�� ���� - �ڽ��� ��ġ ����
        dir = target.transform.position - transform.position;

        dir.y = 0;

        //2. ������ ����ȭ
        dir.Normalize();

        //lookAt() : Ư���� ����� �ٶ󺸴� �Լ�
        transform.LookAt(target.transform);

        //3.���� ���͸� ���� ���� ������ �̵���
        transform.position += dir * speed * Time.deltaTime;*/

        transform.LookAt(target.transform);
        transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, speed * Time.deltaTime);

    }
    //OnTriggerEnter : Trigger �浹�� �̺�Ʈ ȣ��
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        speed = 0;
    }

    //OnTriggerStay() : �浹���϶� �̺�Ʈ ȣ��
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
    }

    //OnTriggerExit() : �浹�� ������ �� �̺�Ʈ ȣ��
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
    }
}
