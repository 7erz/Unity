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


    //1. 게임 오브젝트를 생성
    //2. 리스트에 Unit 게임 오브젝트를 넣어준다.
    //최종적으로 5개 Unit 오브젝트가 리스트에 들어가 있으면 됨
    //createCount로 유연하게 만들기

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
            
            //1. 게임 오브젝트를 생성
            GameObject obje = factory.CreateUnit(unit);

            //2.GameObject 비활성화
            obje.SetActive(false);
            
            //3. 리스트에 Unit 게임 오브젝트를 넣어준다.
            unitList.Add(obje);
            
            //unitList.Add(factory.CreateUnit(unit));

        }
    }

    public GameObject GetObject()
    {
        /*
        //activeCount변수의 값을 증가
        activeCount = activeCount % unitList.Count;


        //activeCount 인덱스로 접근한 게임 오브젝트 비활성화 되어 있는지 확인
        if (unitList[activeCount].activeSelf == false)
        {
            //인덱스로 접근한 게임 오브젝트가 비활성화되어 있다면 활성화
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
