using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnFinishDeath : MonoBehaviour
{
    [SerializeField] private  AudioSource s;

    private void Update()
    {
        if (s.isPlaying == false)
        {
            Destroy(this.gameObject);
        }
    }
}
