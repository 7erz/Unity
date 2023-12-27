using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    [SerializeField] Slider hpSlider;

    //���� ü���� 100 (max�ַµ� 100)


    public void UpdateHP(float health, float maxHealth)
    {
        hpSlider.value = health/maxHealth;
    }
}
