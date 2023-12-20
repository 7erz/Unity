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
        //게임이 실행 될 때 게임 오브젝트의 이름을 검색함.
        target = GameObject.Find("Player");
    }
    //나의 답
    /*
    private void Start()
    {
        //lookAt() : 특정한 대상을 바라보는 함수
        //transform.LookAt(target.transform);
    }

    private void Update()
    {
        transform.LookAt(target.transform);
        transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, 10f * Time.deltaTime);
    }*/

    //추상화 물려줄 때 외부에서 쓰기 위해서 abstract 사용
    public void Update()
    {
        Move();
    }
    public virtual void Move()
    {
        /*
        //1. Target의 벡터 - 자신의 위치 벡터
        dir = target.transform.position - transform.position;

        dir.y = 0;

        //2. 벡터의 정규화
        dir.Normalize();

        //lookAt() : 특정한 대상을 바라보는 함수
        transform.LookAt(target.transform);

        //3.방향 벡터를 구한 값을 가지고 이동함
        transform.position += dir * speed * Time.deltaTime;*/

        transform.LookAt(target.transform);
        transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, speed * Time.deltaTime);

    }
    //OnTriggerEnter : Trigger 충돌시 이벤트 호출
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        speed = 0;
    }

    //OnTriggerStay() : 충돌중일때 이벤트 호출
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
    }

    //OnTriggerExit() : 충돌이 끝났을 때 이벤트 호출
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
    }
}
