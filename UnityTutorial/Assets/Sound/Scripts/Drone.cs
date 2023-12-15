using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public float speed;
    public Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = transform.position;
        //InvokeRepeating() : 특정한 함수를 특정한 시간이 지난 후에
        //특정한 시간마다 반복적으로 호출하는 함수

        //매개변수 1 : 실행할 함수의 이름
        //매개변수 2 : 특정한 시간이 지난 후 실행할 시간
        //매겨변수 3 : 특정한 시간마다 반복적으로 함수를 호출하는 시간
        InvokeRepeating("NewPosition", 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward* speed*Time.deltaTime);
    }
    public void NewPosition()
    {
        transform.position = dir;
        transform.Find("Canvas").gameObject.SetActive(false);
    }
}
