using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDamage : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] float damageAmount;
    [SerializeField] float damageRate;
    [SerializeField] float height = 16f;

    float lastDamageTime;
    float timeSinceLastDamage => Time.time - lastDamageTime;

    private void Awake()
    {
        if (health == null) health = GetComponent<Health>();
    }

    private void Update()
    {
        if (transform.position.y < height)
        {
            if (timeSinceLastDamage > damageRate)
            {
                health.ApplyDamage(damageAmount);
                lastDamageTime = Time.time;
            }
        }
    }
}
