using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //231220
    #region 231120
    //   [0]     [1]
    // �Ҽ�����  ������
    [SerializeField] List<Unit> listUnits;

    [SerializeField] Factory factory;

    private void Start()
    {
        StartCoroutine(CreateRoutine());
    }



    public IEnumerator CreateRoutine()
    {
        while (true)
        {
            // Random.Range : 0 ~ �ִ�-1�� ���� ��ȯ�ϴ� �Լ��Դϴ�. 
            // Random.Range(0, listUnits.Count)
            factory.CreateUnit(listUnits[Random.Range(0, listUnits.Count)]);

            // new WaitForSeconds(5f) : Ư���� �ð����� �ڷ�ƾ�� ����մϴ�.
            yield return new WaitForSeconds(5f);
        }
    }


    #endregion

    //231219
    /*
    //1. ���� 4���� ����
    //2. �ι�°���� �����Ǵ� ���� ��ġ�� x�� + 5;
    [SerializeField] GameObject unit;
    [SerializeField] Transform createPos;
    [Tooltip("������ ������Ʈ ���� ����")]
    [SerializeField] int createCount = 4;

    void Start()
    {
        //Instantiate() : ���� ������Ʈ�� �����ϴ� �Լ�
        //Instantiate(unit);      //�������� ���·� ������
        for(int i = 0; i < createCount; i++)
        {
            //1. ���� ������Ʈ ����
            GameObject monster = Instantiate(unit,createPos);
            //2. ������ ���� ������Ʈ ��ġ ����
            monster.transform.position = new Vector3(i * 5, 0, createPos.position.z);

            Debug.Log("World Pos : " + monster.transform.position);
            Debug.Log("Local Pos : " + monster.transform.localPosition);

            //���� ��
            //unit.transform.position = new Vector3(i*5, 0, 0);
            //Instantiate(unit, createPos);
        }
        //Instantiate(unit,createPos);    //�θ� �ؿ� �ڽ����� ������
    }

    //���丮 ��
    /*[SerializeField] Factory factory;   //���� ������ �־�� ��� ����

    [SerializeField] List<Unit> listUnits;

    float timer = 0f;

    //�ڷ�ƾ
    /*public void Start()
    {
        //UseFactory();
        StartCoroutine(CreateRoutine());

        Debug.Log("Hello World!");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LogRoutine());
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            StopAllCoroutines();
        }
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 5f)
        {
            UseFactory();
            timer = 0f;
        }
    }



    public IEnumerator LogRoutine()
    {
        yield return new WaitForSeconds(1f);

        Debug.Log("Attack");
    }

    public void UseFactory()
    {
        factory.CreateUnit(listUnits[Random.Range(0, listUnits.Count)]); //0~2�� 0,1�� ���� (2����)
    }

    public IEnumerator CreateRoutine()
    {
        while (true)
        {
            factory.CreateUnit(listUnits[Random.Range(0, listUnits.Count)]);

            //WaitForSeconds(�ð�) : Ư���� �ð����� �ڷ�ƾ�� ���

            yield return new WaitForSeconds(5f);
        }

    }*/
}
