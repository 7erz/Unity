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

//�ڵ����� ������Ʈ�� ��
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
        //������ ���� �� �� ���� ������Ʈ�� �̸��� �˻���.
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

        
        //1. Target�� ���� - �ڽ��� ��ġ ����
        dir = target.transform.position - transform.position;
        targetDir = target.transform.position;

        dir.y = 0;
        targetDir.y = 0;

        //2. ������ ����ȭ
        dir.Normalize();

        //lookAt() : Ư���� ����� �ٶ󺸴� �Լ�
        transform.LookAt(targetDir);


        //3.���� ���͸� ���� ���� ������ �̵���
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
    //OnTriggerEnter : Trigger �浹�� �̺�Ʈ ȣ��
    public void OnTriggerEnter(Collider other)
    {
        state = State.Attack;
    }

    //OnTriggerStay() : �浹���϶� �̺�Ʈ ȣ��
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
    }

    //OnTriggerExit() : �浹�� ������ �� �̺�Ʈ ȣ��
    private void OnTriggerExit(Collider other)
    {
        state = State.Move;
    }
}
