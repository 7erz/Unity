using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //1. 몬스터 4마리 생성
    //2. 두번째부터 생성되는 몬스터 위치는 x축 + 5;



    [SerializeField] GameObject unit;
    [SerializeField] Transform createPos;
    [Tooltip("생성할 오브젝트 수량 변수")]
    [SerializeField] int createCount = 4;

    void Start()
    {
        //Instantiate() : 게임 오브젝트를 생성하는 함수
        //Instantiate(unit);      //독립적인 형태로 생성됨
        for(int i = 0; i < createCount; i++)
        {
            //1. 게임 오브젝트 생성
            GameObject monster = Instantiate(unit,createPos);
            //2. 생성된 게임 오브젝트 위치 설정
            monster.transform.position = new Vector3(i * 5, 0, createPos.position.z);

            Debug.Log("World Pos : " + monster.transform.position);
            Debug.Log("Local Pos : " + monster.transform.localPosition);

            //나의 답
            //unit.transform.position = new Vector3(i*5, 0, 0);
            //Instantiate(unit, createPos);
        }
        //Instantiate(unit,createPos);    //부모 밑에 자식으로 생성함
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
