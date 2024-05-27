using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    [SerializeField] float currentHealth;

    Player player;
    Zombie zombie;

    private void Awake()
    {
        player = GetComponent<Player>();
        zombie = GetComponent<Zombie>();
    }

    private void Start()
    {
        ResetHealth();
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public void ApplyDamage(float damage)
    {
        if (!IsAlive) return;
        Debug.Log(name + " took " + damage + " damage");
        currentHealth = Mathf.Max(currentHealth - damage, 0);

        if (player != null) player.UI_Foreground.Attacked();

        if (currentHealth <= 0)
        {
            if (zombie != null) zombie.ZombieDeath();
            else if (player != null) player.PlayerDeath();
        }
    }

    public bool IsAlive => currentHealth > 0;
}
