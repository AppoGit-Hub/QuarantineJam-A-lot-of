using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GameStat
{
    public int BulletShot;
    public int BulletTakenShield;
    public int BulletTakenPlayer;

    public float WalkDistance;

    public int EnemiesSpawned;

    public float Score()
    {
        float Positive = BulletShot + BulletTakenShield + WalkDistance + EnemiesSpawned;
        float Negative = WalkDistance + BulletTakenPlayer;

        return Positive - Negative;
    }
}
