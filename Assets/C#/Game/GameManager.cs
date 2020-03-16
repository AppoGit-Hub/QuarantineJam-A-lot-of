using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager Instance;
    private void Awake() { if (Instance == null) { Instance = this; } }

    [Header("Stat")]
    public GameStat GameStat;

    [Header("Instance")]
    public GameObject PlayerInstance;

    [Header("Manager")]
    public MenuManager      MenuManager;
    public SpawnerManager   SpawnerManager;
    public HolderManager    HolderManager;

    [Header("Camera")]
    [SerializeField] private CameraFollow CameraFollow;

    [Header("Health")]
    [SerializeField] private HealthTracker HeathTracker;

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
        HolderManager.ClearAll();

        SpawnerManager.AllSpawnerDisable = true;

        MenuManager.SwitchToMenu(MenuManager.MenuType.DeathMenu);
        MenuManager.DeathMenu.DisplayStat(GameStat);
    }
    public void ResetGameStat()
    {
        GameStat = new GameStat();
    }
    public void PlayGame()
    {
        HolderManager.ClearAll();
        MenuManager.DisableAllMenu();

        ResetGameStat();

        SpawnerManager.AllSpawnerDisable = false;

        SpawnerManager.SpawnPlayer();

        HeathTracker.HeathOnFocus = PlayerInstance.GetComponent<Health>();
        HeathTracker.ResetHealth();
    }
    public void ExitGame()
    {       
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
