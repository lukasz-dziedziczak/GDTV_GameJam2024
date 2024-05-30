using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player_ZombieSpawning : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] List<ZombieSpawner> zombieSpawners = new List<ZombieSpawner>();
    [SerializeField] List<Zombie> zombies = new List<Zombie>();
    int zombiesToSpawn = 0;
    int round = 0;
    [SerializeField] float spawnRate = 0.5f;
    float lastSpawnTime = 0;
    float timeSinceLastSpawn => Time.time - lastSpawnTime;
    [SerializeField] int baseSpawnAmount;
    [SerializeField] int perRoundAdditional;
    [SerializeField] float idleTime;

    float lastKillTime = Mathf.Infinity;
    float timeSinceLastKill => Time.time - lastKillTime;

    private void Awake()
    {
        Zombie.OnZombieDeath += OnZombieDeath;
    }

    private void OnDisable()
    {
        Zombie.OnZombieDeath -= OnZombieDeath;
    }

    private void Start()
    {
        SetSpawnAmount();
    }

    private void Update()
    {
        if (!Game.Instance.Started) return;

        if (timeSinceLastKill > idleTime)
        {
            SetSpawnAmount();
            lastKillTime = Time.time;
        }

        if (zombiesToSpawn > 0)
        {
            if (timeSinceLastSpawn > spawnRate)
                SpawnZombie();
        }
    }

    private void SpawnZombie()
    {
        if (zombieSpawners.Count == 0 ) return;

        ZombieSpawner spawner = randomSpawner;
        int attempts = 0;
        while (!spawner.SpawnerIsClear && attempts < 100)
        {
            spawner = randomSpawner;
            attempts++;
        }
        if (attempts >= 100) return;

        zombies.Add(spawner.Spawn(round));
        lastSpawnTime = Time.time;
        zombiesToSpawn--;
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("in trigger sphere >> " + other.gameObject.name);
        if (other.gameObject.TryGetComponent<ZombieSpawner>(out ZombieSpawner zombieSpawner))
        {
            if (!zombieSpawners.Contains(zombieSpawner))
            {
                zombieSpawners.Add(zombieSpawner);
                zombieSpawner.SetPlayer(transform.parent);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<ZombieSpawner>(out ZombieSpawner zombieSpawner))
        {
            if (zombieSpawners.Contains(zombieSpawner)) zombieSpawners.Remove(zombieSpawner);
        }

        if (other.gameObject.TryGetComponent<Zombie>(out Zombie zombie))
        {
            if (zombies.Contains(zombie)) zombies.Remove(zombie);
            Destroy(zombie.gameObject);
            zombiesToSpawn++;
        }
    }

    private ZombieSpawner randomSpawner
    {
        get
        {
            if (zombieSpawners.Count > 0) return zombieSpawners[Random.Range(0, zombieSpawners.Count)];
            else return null;
        }
        
    }

    private void SetSpawnAmount()
    {
        zombiesToSpawn = baseSpawnAmount + (round * perRoundAdditional);
    }

    private void OnZombieDeath(Zombie zombie)
    {
        lastKillTime = Time.time;
        if (zombies.Contains(zombie)) zombies.Remove(zombie);

        if (zombies.Count == 0 && zombiesToSpawn == 0)
        {
            round++;
            SetSpawnAmount();
        }
    }

    public void Reset()
    {
        foreach(Zombie zombie in zombies)
        {
            Destroy(zombie.gameObject);
        }
        zombies.Clear();

        round = 0;
        lastSpawnTime = Time.time;
        SetSpawnAmount();
    }
}
