using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    [SerializeField] float despawnTime = 3f;

    bool despawning;
    float despawnStart;
    float timer => Time.time - despawnStart;

    private void Update()
    {
        if (despawning && timer >= despawnTime)
        {
            Destroy(gameObject);
        }    
    }

    public void BeginDespawn()
    {
        despawning = true;
        despawnStart = Time.time;
    }

}
