using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    [SerializeField] float currentHealth;
    [SerializeField] UI_Health healthUI;

    public float CurrentHealth => currentHealth;
    public float MaxHealth => maxHealth;
    public float Percentage => currentHealth / maxHealth;

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

        if (player != null)
        {
            player.UI_Foreground.Attacked();
            player.SFX.PlayBodyHitSound();
        }    

        if (currentHealth <= 0)
        {
            if (zombie != null) zombie.ZombieDeath();
            else if (player != null) player.PlayerDeath();
        }

        healthUI?.UpdateHealth();
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        healthUI?.UpdateHealth();
    }

    public bool IsAlive => currentHealth > 0;
}
