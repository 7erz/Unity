using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
