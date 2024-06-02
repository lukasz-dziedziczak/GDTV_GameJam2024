using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] float amount;

    PickUpSpawner spawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player) && !player.Health.IsFull)
        {
            player.Health.Heal(amount);
            player.SFX.PlayPickUpHealthSound();
            spawn.Clear();
            Game.PickupNotification.Show("Health Pack");
            Destroy(gameObject);
        }
    }

    public void SetSpawner(PickUpSpawner pickUpSpawner)
    {
        spawn = pickUpSpawner;
    }
}
