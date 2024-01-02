using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField] Unit unit;
    [SerializeField] Factory factory;

    [SerializeField] int activeCount = 0;
    [SerializeField] int createCount = 5;
    [SerializeField] List<GameObject> unitList;


    //1. ���� ������Ʈ�� ����
    //2. ����Ʈ�� Unit ���� ������Ʈ�� �־��ش�.
    //���������� 5�� Unit ������Ʈ�� ����Ʈ�� �� ������ ��
    //createCount�� �����ϰ� �����

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        unitList.Capacity = 20;
        CreatePool();
    }

    public void CreatePool()
    {
        for(int i = 0; i < createCount; i++)
        {
            
            //1. ���� ������Ʈ�� ����
            GameObject obje = factory.CreateUnit(unit);

            //2.GameObject ��Ȱ��ȭ
            obje.SetActive(false);
            
            //3. ����Ʈ�� Unit ���� ������Ʈ�� �־��ش�.
            unitList.Add(obje);
            
            //unitList.Add(factory.CreateUnit(unit));

        }
    }

    public GameObject GetObject()
    {
        /*
        //activeCount������ ���� ����
        activeCount = activeCount % unitList.Count;


        //activeCount �ε����� ������ ���� ������Ʈ ��Ȱ��ȭ �Ǿ� �ִ��� Ȯ��
        if (unitList[activeCount].activeSelf == false)
        {
            //�ε����� ������ ���� ������Ʈ�� ��Ȱ��ȭ�Ǿ� �ִٸ� Ȱ��ȭ
            GameObject obj = unitList[activeCount++];

            obj.gameObject.SetActive(true);

            return obj;
        }

        return null;*/
        for (int i = 0; i < unitList.Count; i++)
        {
            int currentIndex = (activeCount + i) % unitList.Count;
            if (!unitList[currentIndex].activeSelf)
            {
                GameObject obj = unitList[currentIndex];
                obj.SetActive(true);
                activeCount = (currentIndex + 1) % unitList.Count;
                return obj;
            }
        }


        return null;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
