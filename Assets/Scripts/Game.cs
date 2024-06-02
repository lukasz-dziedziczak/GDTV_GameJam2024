using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;

    [field: SerializeField] public int KillCount { get; private set; }
    [field: SerializeField] public float MatchLength { get; private set; }
    [field: SerializeField] public bool Started { get; private set; }
    [field: SerializeField] public CameraController CameraController { get; private set; }

    [SerializeField] UI_KillCount killCount;
    [SerializeField] UI_PickupNotification pickupNotification;
    [SerializeField] Transform startCameraPosition;
    [SerializeField] PlayerSpawn[] spawnPoints;
    [SerializeField] UI ui;
    [SerializeField] Player player;

    public static UI_PickupNotification PickupNotification => Instance.pickupNotification;
    public static Transform StartCameraPostion => Instance.startCameraPosition;
    public static UI UI => Instance.ui;
    

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        if (CameraController == null) CameraController = FindObjectOfType<CameraController>();

        Zombie.OnZombieDeath += OnZombieDeath;
    }

    private void Start()
    {
        ShowStartScreen();
        //NewRound();
    }

    private void ShowStartScreen()
    {
        Music.PlayMeunMusic();
        Started = false;
        LockCursor(false);
        UI.SwitchToStart();
        CameraController.SwitchToStartPosition();
    }

    private void OnDisable()
    {
        Zombie.OnZombieDeath -= OnZombieDeath;
    }

    private void OnZombieDeath(Zombie zombie)
    {
        KillCount++;
        killCount?.UpdateKillCount();
    }

    private void Update()
    {
        if (Started)
        {
            MatchLength += Time.deltaTime;
        }
    }

    public void NewRound()
    {
        SpawnPickups();
        KillCount = 0;
        MatchLength = 0;
        killCount.UpdateKillCount();
        CameraController.SwitchToPlayer();
        UI.SwitchToGame();
        LockCursor(true);
        Music.PlayMatchMusic();
        player.StartRound();
        Started = true;
    }

    public void SpawnPickups()
    {
        PickUpSpawner[] spawners = FindObjectsOfType<PickUpSpawner>();

        foreach(PickUpSpawner spawner in spawners)
        {
            spawner.Spawn();
        }
    }

    public static void StartMatch()
    {
        Instance.NewRound();
    }

    public static void EndMatch()
    {
        Instance.Started = false;
        Instance.CameraController.SwitchToStartPosition();
        Instance.ui.SwitchToEnd();
        LockCursor(false);
        Music.PlayMeunMusic();
        Instance.player.ZombieSpawning.MatchEnd();
    }

    public static void ResetRound()
    {
        Instance.SpawnPickups();
        Instance.KillCount = 0;
        Instance.MatchLength = 0;
        Instance.killCount.UpdateKillCount();
        UI.SwitchToGame();
        LockCursor(true);
        Music.PlayMatchMusic();
        Instance.player.StartRound();
        Instance.Started = true;
        Instance.player.ZombieSpawning.MatchEnd();
        Instance.player.ZombieSpawning.MatchStart();
    }

    public static void ReturnToMenu()
    {
        Instance.player.ZombieSpawning.MatchEnd();
        Instance.Started = false;
        Instance.CameraController.SwitchToStartPosition();
        Instance.ui.SwitchToStart();
        Music.PlayMeunMusic();
    }

    public static void LockCursor(bool isLocked)
    {
        Cursor.visible = !isLocked;
        //Update cursor lock state.
        Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
    }

    public static PlayerSpawn RandomSpawn
    {
        get
        {
            return Instance.spawnPoints[UnityEngine.Random.Range(0, Instance.spawnPoints.Length)];
        }
    }
}
