using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    private void Awake()
    {
        //Awake() 함수는 게임 오브젝트가 생성될 때 단 한번만 호출
        //스크립트가 비활성화 상태일때도 호출되는 이벤트 함수
        Debug.Log("Awake");
    }
    private void OnEnable()
    {
        //OnEnable() 함수는 게임 오브젝트가 활성화될 때 마다 호출되는 이벤트 함수
        Debug.Log("OnEnable");
    }
    private void Start()
    {
        //Start() 함수는 게임 오브젝트가 생성될 때 단 한번만 호출
        //스크립트가 비활성화 상태일때는 호출되지 않는 이벤트 함수
        Debug.Log("Start");

    }

    private void FixedUpdate()
    {
        //FixedUpdate() 함수는 timestep에 설정된 값에 따라 일정한 간격으로 호출되는 이벤트 함수
        Debug.Log("FixedUpdate");
    }

    private void Update()
    {
        //Update() 함수는 DeltaTime에 따라 framerate의 불규칙한 간격으로 호췰도는 이벤트 함수
        Debug.Log("Update");
    }

    private void LateUpdate()
    {
        //LateUpdate() 함수는 Update()함수가 호출 된 후
        //한번 씩 호출되는 이벤트 함수
        Debug.Log("LateUpdate");
        //시네머신 카메라
    }

    private void OnDisable()
    {
        //OnDisable() 함수는 게임 오브젝트가 비활성화 되었을 때 호출되는 이벤트 함수
        Debug.Log("OnDisable");
    }

    private void OnDestroy()
    {
        //OnDestroy() 함수는 게임 오브젝트가 삭제 되었을 때 호출되는 이벤트 함수
        Debug.Log("OnDestory");
    }


}
