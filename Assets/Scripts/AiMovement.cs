using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AiMovement : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] LayerMask _whatIsGround, _whatIsPlayer;
    
    // Patroling
    private bool walkPointSet;
    [SerializeField] Vector3 walkPoint;
    [SerializeField] float walkPointRange;
    
    // Attacking
    [SerializeField] float timeBetweenAttacks;
    private bool alreadyAttacked;
    
    // States
    [SerializeField] float sightRange, attackRange;
    [SerializeField] private bool playerInSightRange, playerInAttackRange;
    
    private Animator _animator;

    private void Awake()
    {
        _target = GameObject.Find("Player").transform;
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, _whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, _whatIsPlayer);
        
        if(!playerInSightRange && !playerInAttackRange) Patroling();
        if(playerInSightRange && !playerInAttackRange) ChasePlayer();
        if(playerInSightRange && playerInAttackRange) AttackPlayer();
        
        _animator.SetFloat("velocity", Mathf.Abs(_agent.velocity.x));
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
        
        if (walkPointSet)
            _agent.SetDestination(walkPoint);
        
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        
        if (Physics.Raycast(walkPoint, -transform.up, 2f, _whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        _agent.SetDestination(_target.position);
    }

    private void AttackPlayer()
    {
        _agent.SetDestination(_target.position);
        transform.LookAt(_target);

        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
