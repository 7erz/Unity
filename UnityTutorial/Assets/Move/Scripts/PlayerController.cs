using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 dir;
    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        //Input.GetAxis() : 특정한 key를 누를 때 -1 ~ 1 사이의 값을 반환하는 함수
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        //벡터의 정규화
        dir.Normalize();

        //Time.deltaTime : 이전 프레임이 완료되는 데 까지 걸린 시간 의미
        Debug.Log(Time.deltaTime);
        transform.position += dir * speed * Time.deltaTime;
    }
}
