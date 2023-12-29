using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataManager : MonoBehaviour
{
    public static CharacterDataManager Instance;

    [SerializeField] int selectCount;

    public int SelectCount
    {
        get
        {
            return selectCount;
        }
        set
        {
            selectCount = value;
            Save();
        }
    }
    
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        Load();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Score", selectCount);
    }

    public void Load()
    {
        Debug.Log(PlayerPrefs.GetInt("Score"));
        selectCount = PlayerPrefs.GetInt("Score");
    }


}
