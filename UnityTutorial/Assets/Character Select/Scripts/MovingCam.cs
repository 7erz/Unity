using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCam : MonoBehaviour
{
    //[SerializeField] Transform camTransform;
    //[SerializeField] int characterIndex;


    [SerializeField] List<GameObject> characterList;

    private void Start()
    {
        characterList.Capacity = 5;

    }

    public void Show()
    {
        for(int i = 0; i < characterList.Count; i++)
        {
            characterList[i].SetActive(false);
        }
        characterList[CharacterDataManager.Instance.SelectCount].SetActive(true);
        transform.position = new Vector3(CharacterDataManager.Instance.SelectCount, 0, 0);
    }


    public void CamLeft()
    {
        if(CharacterDataManager.Instance.SelectCount != 0)
        {
            CharacterDataManager.Instance.SelectCount--;
        }
        else
        {
            CharacterDataManager.Instance.SelectCount = characterList.Count - 1;
        }
    }

    public void CamRight()
    {
        if (CharacterDataManager.Instance.SelectCount != characterList.Count - 1)
        {
            CharacterDataManager.Instance.SelectCount++;
        }
        else
        {
            CharacterDataManager.Instance.SelectCount = 0;
        }
    }

    public void Update()
    {
        transform.position = new Vector3(CharacterDataManager.Instance.SelectCount *(-3), 1, 2.5f);
    }

    /*
    //public void CamGoLeft()
    //{
    //    if(characterIndex != 0)
    //    {
    //        characterIndex--;
    //    }
    //    else
    //    {
    //        characterIndex = 2;
    //    }
    //    CamMove();
    //}

    //public void CamGoRight()
    //{
    //    if (characterIndex != 2)
    //    {
    //        characterIndex++;
    //    }else
    //    {
    //        characterIndex = 0;
    //    }
    //    CamMove();
    //}

    //public void CamMove()
    //{
    //    transform.position = new Vector3(transform.position.x + (characterIndex * 3), transform.position.y, transform.position.z);
    //}*/

}
