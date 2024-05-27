using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] Zombie[] zombiePrefabs;
    [SerializeField] LayerMask zombieLayer;
    [SerializeField] float clearanceRadius = 2f;
    [SerializeField] float spawnRate = 3f;

    Transform player;
    float lastSpawnTime = Mathf.NegativeInfinity;
    float timeSinceLastSpawn => Time.time - lastSpawnTime;

    private Zombie zombiePrefab => zombiePrefabs[Random.Range(0, zombiePrefabs.Length)];

    public Zombie Spawn(int round)
    {
        if (zombiePrefabs.Length <= 0) return null;
        FacePlayer();
        Zombie zombie = Instantiate(zombiePrefab, transform.position, transform.rotation);
        zombie.AI.Initilize(round);
        lastSpawnTime = Time.time;
        return zombie;
    }

    private void FacePlayer()
    {
        if (player == null) return;

        transform.LookAt(player.position);
        //print(name + " new rotation = " + transform.eulerAngles);
        transform.eulerAngles = new Vector3(
            0, transform.eulerAngles.y, 0);
    }

    public void SetPlayer(Transform transform)
    {
        //print(name + ": Setting player as " + transform.name);
        player = transform;
    }

    public bool SpawnerIsClear
    {
        get
        {
            if (Physics.SphereCast(transform.position, clearanceRadius, transform.up, out RaycastHit hit, clearanceRadius, zombieLayer))
                return false;
            else if (timeSinceLastSpawn < spawnRate) return false;

            return true;
        }
    }
}
