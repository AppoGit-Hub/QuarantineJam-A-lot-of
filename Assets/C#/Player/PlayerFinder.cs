using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinder : MonoBehaviour
{
    [HideInInspector] public GameObject Player;
    private void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
}
