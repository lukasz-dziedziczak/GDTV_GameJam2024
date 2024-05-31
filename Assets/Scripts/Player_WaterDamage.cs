using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_WaterDamage : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] float damageAmount;
    [SerializeField] float damageRate;
    [SerializeField] float height = 16f;

    float lastDamageTime;
    float timeSinceLastDamage => Time.time - lastDamageTime;

    private void Awake()
    {
        if (player == null) player = GetComponent<Player>();
    }

    private void Update()
    {
        if (transform.position.y < height)
        {
            if (timeSinceLastDamage > damageRate)
            {
                player.Health.ApplyDamage(damageAmount);
                lastDamageTime = Time.time;
            }
        }
    }
}
