using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    [SerializeField] Slider hpSlider;

    //현재 체력이 100 (max최력도 100)


    public void UpdateHP(float health, float maxHealth)
    {
        hpSlider.value = health/maxHealth;
        //if(hpSlider.value == 0)
        //{
        //    transform.Find
        //}
    }
}
