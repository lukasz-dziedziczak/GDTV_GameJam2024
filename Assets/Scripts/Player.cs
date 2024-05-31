using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfimaGames.LowPolyShooterPack;

public class Player : MonoBehaviour
{
    [field: SerializeField] public Character Character {  get; private set; }
    [field: SerializeField] public Health Health { get; private set; }
    [field: SerializeField] public UI_Foreground UI_Foreground { get; private set; }
    [field: SerializeField] public Player_ZombieSpawning ZombieSpawning { get; private set; }
    [field: SerializeField] public Ammo RifleAmmo { get; private set; }
    [field: SerializeField] public Ammo PistolAmmo { get; private set; }
    [field: SerializeField] public Player_SFX SFX { get; private set; }
    [field: SerializeField] public Transform CameraSocket { get; private set; }
    [field: SerializeField] public Inventory Inventory { get; private set; }

    int spawning;
    PlayerSpawn spawn;

    private void Awake()
    {
        if (UI_Foreground == null) UI_Foreground = FindObjectOfType<UI_Foreground>();
    }

    private void Update()
    {
        if (spawning-- > 0)
        {
            spawn.Spawn(this);
        }
    }

    public void PlayerDeath()
    {
        print("Player died");

        Game.EndMatch();
    }

    public void StartRound()
    {
        Health.ResetHealth();
        RifleAmmo.Reset();
        PistolAmmo.Reset();
        ZombieSpawning.MatchStart();
        Inventory.MatchStart();
        spawn = Game.RandomSpawn;
        spawning = 9;
    }

}
