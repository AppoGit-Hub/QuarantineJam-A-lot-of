using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private AudioSource MetalSound;
    [SerializeField] private ShieldBulletTaken SBT;

    private void OnCollisionEnter(Collision collision)
    {
        MetalSound.Play();

        SBT.Add(1);
    }
}
