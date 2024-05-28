using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [field: SerializeField] public Health Health { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public Despawner Despawner { get; private set; }
    [field: SerializeField] public CapsuleCollider Collider { get; private set; }
    [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
    [field: SerializeField] public NavMeshAgent NavMeshAgent { get; private set; }
    [field: SerializeField] public ZombieClaw LeftClaw { get; private set; }
    [field: SerializeField] public ZombieClaw RightClaw { get; private set; }
    [field: SerializeField] public ZombieAI AI { get; private set; }
    [field: SerializeField] public ZombieSound Sound { get; private set; }
    [field: SerializeField] public Transform Head { get; private set; }
    [field: SerializeField] public float HeadshotDistance { get; private set; }

    public static event Action<Zombie> OnZombieDeath;

    private void Awake()
    {
        if (Animator == null) Animator = GetComponentInChildren<Animator>();
        name = "Zomie" + (UnityEngine.Random.Range(100, 1000)).ToString();
    }

    private void Start()
    {
        
    }

    public void ZombieDeath()
    {
        print(name + " died");
        Animator.SetTrigger("death");
        Rigidbody.useGravity = false;
        Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        Collider.isTrigger = true;
        NavMeshAgent.isStopped = true;
        Despawner.BeginDespawn();
        Sound.OnDeath();
        TurnOffClaws();
        OnZombieDeath?.Invoke(this);
    }

    public bool IsGettingUp
    {
        get
        {
            AnimatorStateInfo currentStateInfo = Animator.GetCurrentAnimatorStateInfo(0);
            if (currentStateInfo.IsTag("StandingUp") && currentStateInfo.normalizedTime < 1)
            {
                return true;
            }

            return false;
        }
    }

    public void TurnOffClaws()
    {
        LeftClaw?.Active(false);
        RightClaw?.Active(false);
    }


}
