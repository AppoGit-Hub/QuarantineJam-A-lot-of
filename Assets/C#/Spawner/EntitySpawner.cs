using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    public void Spawn(GameObject g, Transform p, Vector3 pos)
    {
        GameObject o = Instantiate(g, pos, Quaternion.identity, p);

        //GameManager.Instance.GameStat.EnemiesSpawned += 1;
    }
    public Vector3 ChosseRandomSpawn(Transform Spawns)
    {
        return (Spawns.GetChild(Random.Range(0, Spawns.childCount - 1)).position);
    }
}
