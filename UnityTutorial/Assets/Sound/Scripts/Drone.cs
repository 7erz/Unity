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
        //InvokeRepeating() : Ư���� �Լ��� Ư���� �ð��� ���� �Ŀ�
        //Ư���� �ð����� �ݺ������� ȣ���ϴ� �Լ�

        //�Ű����� 1 : ������ �Լ��� �̸�
        //�Ű����� 2 : Ư���� �ð��� ���� �� ������ �ð�
        //�Űܺ��� 3 : Ư���� �ð����� �ݺ������� �Լ��� ȣ���ϴ� �ð�
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
