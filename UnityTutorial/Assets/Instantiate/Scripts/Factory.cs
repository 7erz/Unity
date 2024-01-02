using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] Transform spawnPos;

    //데이터리스트

    //게임 오브젝트
    

    //Unit -> 소서리스, 마법사, 전사 등 여기에 있는 코드는 바뀌지 않음
    public GameObject CreateUnit(Unit unit)
    {
        //게임 오브젝트 생성
        GameObject monster = Instantiate(unit.gameObject,spawnPos);
        //게임 오브젝트 반환
        return monster;
    }
}
