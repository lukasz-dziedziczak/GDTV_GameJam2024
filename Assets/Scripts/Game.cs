using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;

    [field: SerializeField] public int KillCount { get; private set; }
    [field: SerializeField] public float MatchLength { get; private set; }
    [field: SerializeField] public bool Started { get; private set; } = true;

    [SerializeField] UI_KillCount killCount;
    [SerializeField] UI_PickupNotification pickupNotification;

    public static UI_PickupNotification PickupNotification => Instance.pickupNotification;
    

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        Zombie.OnZombieDeath += OnZombieDeath;
    }

    private void Start()
    {
        NewRound();
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

}
