using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField]
    private int speed = 5;
    public int hp = 100;

    void Start()
    {
        Debug.Log("hp : " + hp);

    }


}
