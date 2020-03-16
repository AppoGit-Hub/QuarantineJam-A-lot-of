using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [Header("Spawner")]
    public EntitySpawner EnemySpawner;
    public EntitySpawner HealthDropSpawner;

    [Header("Holder")]
    public Transform SoundHolder;
    public Transform BulletHolder;
    public Transform PlayerHolder;
    public Transform EnemyHolder;
    public Transform ParticuleHolder;
    public Transform HealthDropHolder;

    [Header("SpawnPoint")]
    public Transform EnemySpawnPoint;
    public Transform HealthSpawnPoint;

    [Header("Prefab")]
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private GameObject HealthDropPrefab;

    [Header("Rater")]
    [SerializeField] [Range(30, 480)] private int EnemySpawnRate = 120;
    [SerializeField] [Range(120, 720)] private int HealthDropSpawnRate = 400;

    private StopWatch EnemySpawnWaiter = new StopWatch();
    private StopWatch HealthDropSpawnWaiter = new StopWatch();

    [HideInInspector] public bool AllSpawnerDisable = false;

    private void Start()
    {
        EnemySpawnWaiter.SetWait(SpawnEnemy, EnemySpawnRate, 0, true);
        HealthDropSpawnWaiter.SetWait(SpawnHealthDrop, HealthDropSpawnRate, 0, true);
    }
    private void Update()
    {
        if (AllSpawnerDisable) return;
        
        EnemySpawnWaiter.Update();
        HealthDropSpawnWaiter.Update();
    }

    ////////////////////////////////////////////// Spawn Entity //////////////////////////////////////////////
    private GameObject SpawnEntity(GameObject g, Transform p, Vector3 pos)
    {
        return Instantiate(g, pos, Quaternion.identity, p);
    }
    public void SpawnPlayer()
    {
        GameManager.Instance.PlayerInstance = SpawnEntity(PlayerPrefab, PlayerHolder, PlayerHolder.transform.position);
    }
    public void SpawnEnemy()
    {
        GameObject e = this.SpawnEntity(EnemyPrefab, EnemyHolder, EnemySpawner.ChosseRandomSpawn(EnemySpawnPoint));
    }
    public void SpawnHealthDrop()
    {
        GameObject hd = this.SpawnEntity(HealthDropPrefab, HealthDropHolder, HealthDropSpawner.ChosseRandomSpawn(HealthSpawnPoint));
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
}
