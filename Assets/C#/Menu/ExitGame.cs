﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void Exit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
