using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Move,
    Attack,
    Die,
    None
}

//자동으로 컴포넌트가 들어감
[RequireComponent(typeof(Hpbar))]
public abstract class Unit : MonoBehaviour
{
    [SerializeField] GameObject target;

    [SerializeField] Vector3 dir;
    [SerializeField] Vector3 targetDir;

    [SerializeField] State state;

    [SerializeField] Animator animator;

    [SerializeField] float speed;

    [SerializeField] protected float health;
    [SerializeField] protected float maxHealth;
    [SerializeField] Hpbar hpbar;

    [SerializeField] Sound sound = new Sound();

    private void Awake()
    {
        //게임이 실행 될 때 게임 오브젝트의 이름을 검색함.
        target = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        hpbar = GetComponent<Hpbar>();

    }

    public void OnHit(float damage)
    {
        if (health <= 0)
        {
            return;
        }

        health -= damage;

        if(health <= 0 && state != State.Die)
        {
            state = State.Die;
        }
    }

    public virtual void Release()
    {
        Destroy(gameObject);
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnHit(10);
        }
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
        hpbar.UpdateHP(health,maxHealth);
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

    public void AttackSound()
    {
        SoundManager.instance.Sound(sound.audioClips[0]);
    }
    public virtual void Die()
    {
        animator.Play("Die");
        SoundManager.instance.Sound(sound.audioClips[1]);
        state = State.None;
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
