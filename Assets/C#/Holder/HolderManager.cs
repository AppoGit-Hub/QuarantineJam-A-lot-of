using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderManager : MonoBehaviour
{
    [Header("Holder")]
    public Transform SoundHolder;
    public Transform BulletHolder;
    public Transform PlayerHolder;
    public Transform EnemyHolder;
    public Transform ParticuleHolder;
    public Transform HealthDropHolder;

    ////////////////////////////////////////////// Kill Holder //////////////////////////////////////////////
    public void KillHolder(Transform Holder)
    {
        foreach (Transform h in Holder)
        {
            Destroy(h.gameObject);
        }
    }
    public void KillAllEnemies()
    {
        KillHolder(EnemyHolder);
    }
    public void KillAllSound()
    {
        KillHolder(EnemyHolder);
    }
    public void KillAllBullet()
    {
        KillHolder(BulletHolder);
    }
    public void KillAllParticule()
    {
        KillHolder(ParticuleHolder);
    }
    public void KillAllHealthDrop()
    {
        KillHolder(HealthDropHolder);
    }
    public void ClearAll()
    {
        KillAllEnemies();
        KillAllBullet();
        KillAllHealthDrop();
        KillAllParticule();
        KillAllSound();
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
}
