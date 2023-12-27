using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RIfle : MonoBehaviour
{
    private Ray ray;
    private RaycastHit raycastHit;
    [SerializeField] int bulletDmg = 10;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Sound sound = new Sound();


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SoundManager.instance.Sound(sound.audioClips[0]);
            //3차원 공간에 넣어줌
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out raycastHit, Mathf.Infinity,layerMask))
            {
                //Debug.Log(raycastHit.collider.name + "과 충돌 함.");
                raycastHit.collider.GetComponent<Unit>().OnHit(bulletDmg);
            }
        }
    }
}
