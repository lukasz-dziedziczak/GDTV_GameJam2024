using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimationCalls : MonoBehaviour
{
    [SerializeField] Zombie zombie;

    private void Awake()
    {
        if (zombie == null) zombie = GetComponentInParent<Zombie>();
    }

    public void TurnOnLeftHand()
    {
        zombie.LeftClaw?.Active(true);
    }

    public void TurnOffLeftHand()
    {
        zombie.LeftClaw?.Active(false);
    }

    public void TurnOnRightHand()
    {
        zombie.RightClaw?.Active(true);
    }

    public void TurnOffRightHand()
    {
        zombie.RightClaw?.Active(false);
    }
}
