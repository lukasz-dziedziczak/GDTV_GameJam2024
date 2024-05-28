using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ammo : MonoBehaviour
{
    [field: SerializeField] public int Amount { get; private set; }
    [field: SerializeField] public EType Type { get; private set; }

    int startingAmmo;

    private void Awake()
    {
        startingAmmo = Amount;
    }

    public void Add(int amount)
    {
        Amount += amount;
    }

    public void Remove(int amount)
    {
        Amount -= amount;
    }

    public enum EType
    {
        None,
        Rifle,
        Pistol
    }

    public void Reset()
    {
        Amount = startingAmmo;
    }

}
