using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //231220
    #region 231120
    //   [0]     [1]
    // 소서리스  마법사
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
            // Random.Range : 0 ~ 최댓값-1의 값을 반환하는 함수입니다. 
            // Random.Range(0, listUnits.Count)
            factory.CreateUnit(listUnits[Random.Range(0, listUnits.Count)]);

            // new WaitForSeconds(5f) : 특정한 시간동안 코루틴을 대기합니다.
            yield return new WaitForSeconds(8f);
        }
    }


    #endregion

    //231219
    /*
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

    //팩토리 후
    /*[SerializeField] Factory factory;   //월드 공간에 있어야 사용 가능

    [SerializeField] List<Unit> listUnits;

    float timer = 0f;

    //코루틴
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
        factory.CreateUnit(listUnits[Random.Range(0, listUnits.Count)]); //0~2라서 0,1만 나옴 (2빼고)
    }

    public IEnumerator CreateRoutine()
    {
        while (true)
        {
            factory.CreateUnit(listUnits[Random.Range(0, listUnits.Count)]);

            //WaitForSeconds(시간) : 특정한 시간동안 코루틴을 대기

            yield return new WaitForSeconds(5f);
        }

    }*/
}
