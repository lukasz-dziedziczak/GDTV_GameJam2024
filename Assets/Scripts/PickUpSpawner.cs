using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] EType type;
    [SerializeField] AmmoBox rifleAmmoPickupPrefab;
    [SerializeField] AmmoBox pistolAmmoPickupPrefab;
    [SerializeField] HealthPickUp healthPickupPrefab;

    AmmoBox ammoBox;
    HealthPickUp healthPickUp;

    public enum EType
    {
        None,
        Ammo,
        PistolAmmo,
        RifleAmmo,
        Health
    }

    private void Update()
    {

    }

    public void Spawn()
    {
        if (!SpawnPointClear) return;

        if (type != EType.None) SpawnType(type);
        else
        {
            int random = Random.Range(2, 5);
            SpawnType((EType)random);
        }
    }

    private void SpawnType(EType type)
    {
        switch (type)
        {
            case EType.PistolAmmo:
                ammoBox = Instantiate(pistolAmmoPickupPrefab, transform.position, transform.rotation);
                break;

            case EType.RifleAmmo:
                ammoBox = Instantiate(rifleAmmoPickupPrefab, transform.position, transform.rotation);
                break;

            case EType.Health:
                healthPickUp = Instantiate(healthPickupPrefab, transform.position, transform.rotation);
                break;

            case EType.Ammo:
                int randomChance = Random.Range(0, 2);
                if (randomChance == 0)
                {
                    ammoBox = Instantiate(pistolAmmoPickupPrefab, transform.position, transform.rotation);
                }
                else
                {
                    ammoBox = Instantiate(rifleAmmoPickupPrefab, transform.position, transform.rotation);
                }
                break;
        }

        if (ammoBox != null) ammoBox.SetSpawner(this);
        else if (healthPickUp != null) healthPickUp.SetSpawner(this);
    }

    private bool SpawnPointClear
    {
        get
        {
            return ammoBox == null && healthPickUp == null;
        }
    }

    public void Clear()
    {
        ammoBox = null;
        healthPickUp = null;
    }
}
