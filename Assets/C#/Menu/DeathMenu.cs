using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : Menu
{
    [Header("Content")]
    [SerializeField] private Text Score;

    public void DisplayStat(GameStat gs)
    {
        Score.text = gs.Score().ToString();
    }
}
