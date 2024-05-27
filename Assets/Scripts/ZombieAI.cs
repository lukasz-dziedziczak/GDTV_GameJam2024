using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    [SerializeField] Zombie zombie;
    [SerializeField] bool isRunner;
    [SerializeField, Range(0, 1)] float chanceToBeRunnerBase;
    [SerializeField, Range(0, 1)] float chanceIncreasePerRound = 0.05f; 
    [SerializeField] float walkingSpeed = 1;
    [SerializeField] float runningSpeed = 3.5f;
    [SerializeField] float attackRange;

    Player player;

    private float animationSpeed => isRunner ? 2 : 1;
    private float speed => isRunner ? runningSpeed : walkingSpeed;

    private void Awake()
    {
        if (zombie == null) zombie = GetComponent<Zombie>();
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (zombie.IsGettingUp || !zombie.Health.IsAlive) return;

        if (!player.Health.IsAlive)
        {
            zombie.Animator.SetFloat("speed", 0);
            zombie.Animator.SetBool("attacking", false);
            zombie.NavMeshAgent.isStopped = true;
            return;
        }

        if (distanceToPlayer > (isRunner? attackRange*2 : attackRange))
        { // move to player untill in range
            zombie.NavMeshAgent.isStopped = false;
            zombie.Animator.SetBool("attacking", false);
            zombie.NavMeshAgent.SetDestination(player.transform.position);
        }
        else // attack player
        {
            FacePlayer();
            zombie.NavMeshAgent.isStopped = true;
            zombie.Animator.SetBool("attacking", true);
        }

        if (zombie.NavMeshAgent.velocity.magnitude > 0)
            zombie.Animator.SetFloat("speed", animationSpeed);
        else
            zombie.Animator.SetFloat("speed", 0);
    }

    private float distanceToPlayer => Vector3.Distance(transform.position, player.transform.position);

    public void Initilize(int round)
    {
        float random = UnityEngine.Random.Range(0f, 1f);
        //print("change to be runner = " + chanceToBeRunner + ", random = " + random);
        float chanceToBeRunner = chanceToBeRunnerBase + (chanceIncreasePerRound * round);
        isRunner = random <= chanceToBeRunner;
        zombie.NavMeshAgent.speed = speed;
    }

    private void FacePlayer()
    {
        if (player == null) return;

        transform.LookAt(player.transform.position);
        transform.eulerAngles = new Vector3(
            0, transform.eulerAngles.y, 0);
    }
}
