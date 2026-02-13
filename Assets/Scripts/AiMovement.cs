using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AiMovement : MonoBehaviour
{
    [Header("")]
    [SerializeField] Transform _target;
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] LayerMask _whatIsGround, _whatIsPlayer;
    
    // Patroling
    [Header("Patroling")]
    private bool walkPointSet;

    [SerializeField] private float timeBetweenChangingPatrolingPoints;
    [SerializeField] Vector3 walkPoint;
    [SerializeField] float walkPointRange;
    
    // Attacking
    [Header("Attacking")]
    [SerializeField] float timeBetweenAttacks;
    private bool alreadyAttacked;
    
    // States
    [Header("States")]
    [SerializeField] float sightRange, attackRange;
    [SerializeField] private bool playerInSightRange, playerInAttackRange;
    
    [Header("Audio")]
    [SerializeField] AudioSource _audioSource;

    [SerializeField] AudioClip[] _audioClipSteps;
    [SerializeField] AudioClip[] _audioClipVoice;
    
    private Animator _animator;
    [SerializeField] private PlayerHealth _playerHealth;

    private Coroutine _attackCoroutine;
    
    
    private void Awake()
    {
        _target = GameObject.Find("Player").transform;
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, _whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, _whatIsPlayer);
        
        if(!playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }
        else
        {
            _animator.SetBool("Attack", false);
        }
   
        
        // Animation
        _animator.SetFloat("velocity", Mathf.Abs(_agent.velocity.x));
    }
    
    

    private void PlayerFootSteps()
    {
        _audioSource.PlayOneShot(_audioClipSteps[Random.Range(0, _audioClipSteps.Length)]);
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
        _animator.SetBool("Attack", true);
    }

    private IEnumerator IfStuck()
    {
        yield return new WaitForSeconds(10f);
        SearchWalkPoint();
    }

    private void OnFootSteps()
    {
        PlayerFootSteps();
    }

    private void OnMonsterAttack()
    {
        _playerHealth.LoseHealth() ;
    }
}
