using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [SerializeField] Ammo.EType type = Ammo.EType.Rifle;
    [SerializeField] int amount = 60;

    PickUpSpawner spawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            if (type == Ammo.EType.Rifle)
            {
                player.RifleAmmo.Add(amount);
                Game.PickupNotification.Show("Rifle Ammo");
            }
            else if (type == Ammo.EType.Pistol)
            {
                player.PistolAmmo.Add(amount);
                Game.PickupNotification.Show("Pistol Ammo");
            }
            player.SFX.PlayPickUpAmmoSound();
            spawn.Clear();
            Destroy(gameObject);
        }
    }

    public void SetSpawner(PickUpSpawner pickUpSpawner)
    {
        spawn = pickUpSpawner;
    }
}
