using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        Debug.Log("Load Game");
    }

    public void Option()
    {
        Debug.Log("Option");
    }

    public void GameQuit()
    {
        Debug.Log("Game Quit");
    }
}
