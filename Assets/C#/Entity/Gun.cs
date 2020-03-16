using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform BulletSpawnPoint;

    [SerializeField] private AudioSource ShootSound;
    
    public void Shoot()
    {
        Instantiate(Bullet, BulletSpawnPoint.position, BulletSpawnPoint.rotation, GameManager.Instance.BulletHolder);
        ShootSound.Play();

        GameManager.Instance.GameStat.BulletShot++;
    }
}
