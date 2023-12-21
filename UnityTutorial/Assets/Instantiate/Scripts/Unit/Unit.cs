using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Move,
    Attack,
    Die
}

public abstract class Unit : MonoBehaviour
{
    [SerializeField] GameObject target;

    [SerializeField] Vector3 dir;
    [SerializeField] Vector3 targetDir;

    [SerializeField] float speed;

    [SerializeField] State state;

    [SerializeField] Animator animator;




    private void Awake()
    {
        //게임이 실행 될 때 게임 오브젝트의 이름을 검색함.
        target = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        
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
        switch (state)
        {
            case State.Move:
                Move();
                break;
            case State.Attack:
                Attack();
                break;
            case State.Die:
                Die();
                break;

        }
    }
    public virtual void Move()
    {
        animator.SetBool("Attack", false);

        
        //1. Target의 벡터 - 자신의 위치 벡터
        dir = target.transform.position - transform.position;
        targetDir = target.transform.position;

        dir.y = 0;
        targetDir.y = 0;

        //2. 벡터의 정규화
        dir.Normalize();

        //lookAt() : 특정한 대상을 바라보는 함수
        transform.LookAt(targetDir);


        //3.방향 벡터를 구한 값을 가지고 이동함
        transform.position += dir * speed * Time.deltaTime;



        /*transform.LookAt(target.transform);
        transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, speed * Time.deltaTime);*/

    }

    public virtual void Attack()
    {
        animator.SetBool("Attack", true);
    }
    public virtual void Die()
    {

    }
    //OnTriggerEnter : Trigger 충돌시 이벤트 호출
    public void OnTriggerEnter(Collider other)
    {
        state = State.Attack;
    }

    //OnTriggerStay() : 충돌중일때 이벤트 호출
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
    }

    //OnTriggerExit() : 충돌이 끝났을 때 이벤트 호출
    private void OnTriggerExit(Collider other)
    {
        state = State.Move;
    }
}
