using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] Transform spawnPos;

    //�����͸���Ʈ

    //���� ������Ʈ
    

    //Unit -> �Ҽ�����, ������, ���� �� ���⿡ �ִ� �ڵ�� �ٲ��� ����
    public GameObject CreateUnit(Unit unit)
    {
        //���� ������Ʈ ����
        GameObject monster = Instantiate(unit.gameObject,spawnPos);
        //���� ������Ʈ ��ȯ
        return monster;
    }
}
