using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsGameManager : MonoBehaviour
{
    public void GameOver()
    {
        Time.timeScale = 0;
        Debug.Log("Game Over");
    }
}
