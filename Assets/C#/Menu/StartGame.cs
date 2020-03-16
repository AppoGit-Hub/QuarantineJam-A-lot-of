using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public void GameStart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
