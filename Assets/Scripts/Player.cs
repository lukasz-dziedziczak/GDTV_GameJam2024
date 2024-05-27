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

    private void Awake()
    {
        UI_Foreground = FindObjectOfType<UI_Foreground>();
    }

    public void PlayerDeath()
    {
        print("Player died");
        PlayerSpwan.ResetPlayerPosition();
        Health.ResetHealth();
        ZombieSpawning.Reset();
    }

}
