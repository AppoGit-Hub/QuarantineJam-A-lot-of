using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager Instance;
    private void Awake() { if (Instance == null) { Instance = this; } }

    [Header("Stat")]
    public GameStat GameStat;

    [Header("Holder")]
    public Transform SoundHolder;
    public Transform BulletHolder;
    public Transform PlayerHolder;
    public Transform EnemyHolder;
    public Transform ParticuleHolder;
    public Transform HealthDropHolder;

    [Header("Spawner")]
    [SerializeField] private EntitySpawner EnemySpawner;
    [SerializeField] private EntitySpawner HealthDropSpawner;

    [Header("SpawnPoint")]
    public Transform EnemySpawnPoint;
    public Transform HealthSpawnPoint;

    [Header("Prefab")]
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private GameObject HealthDropPrefab;

    [Header("Instance")]
    public GameObject PlayerInstance;

    [Header("Manager")]
    [SerializeField] private MenuManager MenuManager;

    [Header("Camera")]
    [SerializeField] private CameraFollow CameraFollow;

    [Header("Health")]
    [SerializeField] private HealthTracker HeathTracker;

    [Header("Rater")]
    [SerializeField] [Range(30, 480)] private int EnemySpawnRate = 120;
    [SerializeField] [Range(120, 720)] private int HealthDropSpawnRate = 400;


    private StopWatch EnemySpawnWaiter = new StopWatch();
    private StopWatch HealthDropSpawnWaiter = new StopWatch();


    private void Start()
    {
        EnemySpawnWaiter.SetWait(SpawnEnemy, EnemySpawnRate, 0, true);
        HealthDropSpawnWaiter.SetWait(SpawnHealthDrop, HealthDropSpawnRate, 0, true);
    }
    private void Update()
    {
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
        this.PlayerInstance = SpawnEntity(PlayerPrefab, PlayerHolder, PlayerHolder.transform.position);
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
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //////////////////////////////////////////////    Menu       //////////////////////////////////////////////

    public void RestartGame()
    {

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void ReportEvent(GameObject s, Event e)
    {
        if (e.GetType() == typeof(DeathEvent))
        {
            DeathReported(e as DeathEvent);
        }
    }
    private void DeathReported(DeathEvent e)
    {
        if (e.DeadObject.tag == "Player")
        {
            PlayerDie();
        }
    }
    public void PlayerDie()
    {
        ClearGameScene();

        MenuManager.SwitchToMenu(MenuManager.MenuType.DeathMenu);
        MenuManager.DeathMenu.DisplayStat(GameStat);

        EnemySpawner.gameObject.SetActive(false);
        HealthDropSpawner.gameObject.SetActive(false);
    }
    public void ResetGameStat()
    {
        GameStat = new GameStat();
    }
    public void ClearGameScene()
    {
        KillAllEnemies();
        KillAllBullet();
        KillAllHealthDrop();
        KillAllParticule();
        KillAllSound();
    }

    public void PlayGame()
    {
        ClearGameScene();

        MenuManager.DisableAllMenu();

        EnemySpawner.gameObject.SetActive(true);
        HealthDropSpawner.gameObject.SetActive(true);

        ResetGameStat();
        SpawnPlayer();

        HeathTracker.HeathOnFocus = PlayerInstance.GetComponent<Health>();
        HeathTracker.ResetHealth();
    }
    public void ExitGame()
    {       
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
