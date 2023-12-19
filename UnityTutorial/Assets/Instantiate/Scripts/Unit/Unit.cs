using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    //추상화 물려줄 때 외부에서 쓰기 위해서 abstract 사용

    public abstract void Move();
}
