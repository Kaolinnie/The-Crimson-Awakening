using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAi : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    
    public float speedWalk = 2;
    public float speedRun = 5;

    public float maxDistance = 5;
    public float attackRange = 2;
    public float timer;
    private Animator animator;
    public Transform patrolPoints;
    private static readonly int Attack1 = Animator.StringToHash("Attack");
    private static readonly int CharSpeed = Animator.StringToHash("CharSpeed");
    private int _patrolIndex;
    private bool _chasing;
    public float attackInterval = 1f; // Time between each attack

    private bool isAttacking = false;
    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.speed = speedWalk;
        if (animator!=null) animator.SetFloat(CharSpeed,speedWalk);
        agent.isStopped = false;
        GoToNextPoint();
        _player = Player.Instance;
    }
    
    // Update is called once per frame
    private void Update() {
        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0.0f, 1.0f);
        if (IsInDistance()) {
            _chasing = true;
            agent.speed = speedRun;
            timer = 1.0f;
            agent.destination = player.transform.position;
            AttackPlayer();
        }
        else if (timer > 0) {
            agent.destination = player.transform.position;
        } 
        else if (_chasing) {
            _chasing = false;
            agent.speed = speedWalk;
            agent.destination = patrolPoints.GetChild(_patrolIndex).position;
        }
        else if (!agent.pathPending && agent.remainingDistance < 0.5f) {
            GoToNextPoint();
        } 
    }

    private void AttackPlayer() {
        var mag = (player.transform.position - transform.position).magnitude;
        if (mag < attackRange) {
            if (animator!=null) animator.SetTrigger(Attack1);
            _player.AdjustHealth(-10.0f);
        }
    }

    private void GoToNextPoint()
    {
        if (patrolPoints.childCount == 0) return;
        _patrolIndex = (_patrolIndex + 1) % patrolPoints.childCount; // Increment the _patrolIndex
        agent.destination = patrolPoints.GetChild(_patrolIndex).position;
    }


    private bool IsInDistance() {
        var mag = (player.transform.position - transform.position).magnitude;
        return mag <= maxDistance;
    } 

    // void Move(float speed) {
    //     agent.isStopped = false;
    //     agent.speed = speed;
    // }
    //
    // void Stop() {
    //     agent.isStopped = true;
    //     agent.speed = 0;
    // }
    //
    // void NextWp() {
    //     currentWP = (currentWP + 1) % WP.Length;
    //     agent.SetDestination(WP[currentWP].position);
    // }
    //
    // void PlayerFound () {
    //     t_playerFound = true;
    // }
    //
    // void LookingForPlayer(Vector3 player) {
    //     agent.SetDestination(player);
    //     if(Vector3.Distance(transform.position, player) <= 0.3) {
    //         if(timeWait <= 0) {
    //             t_playerNear = false;
    //             Move(speedWalk);
    //             agent.SetDestination(WP[currentWP].position);
    //             timeWait = startWaitTime;
    //             timeToRotate = t_timeToRotate;
    //         } else {
    //             Stop();
    //             timeWait -= Time.deltaTime;
    //         }
    //     }
    // }
    //
    // //pin = player in range
    // void EnvironmentView() {
    //     Collider[] PIN = Physics.OverlapSphere(transform.position, viewRadius, PM);
    //     for(int i = 0; i < PIN.Length; i++) {
    //         Transform player = PIN[i].transform;
    //         Vector3 playerDirection = (player.position - transform.position).normalized;
    //         if(Vector3.Angle(transform.forward, playerDirection)< viewAngle / 2) {
    //             float playerDistance = Vector3.Distance(transform.position, player.position);
    //             if(!Physics.Raycast(transform.position, playerDirection, playerDistance, OM)) {
    //                 t_playerInRange = true;
    //                 t_IsPatrolling = true;
    //             } else {
    //                 t_playerInRange = false;
    //             }
    //         }
    //
    //         if(Vector3.Distance(transform.position, player.position) > viewRadius) {
    //             t_playerInRange = false;
    //         }
    //
    //         if(t_playerInRange) {
    //             playerPos = player.transform.position;
    //         }
    //     }
    //     
    // } 
    //
    // private void Patrolling() {
    //     if (t_playerNear) {
    //         if (timeToRotate <= 0) {
    //             Move(speedWalk);
    //             LookingForPlayer(playerLastPos);
    //         } else {
    //             Stop();
    //             t_timeToRotate -= Time.deltaTime;
    //         }
    //     } else {
    //         t_playerNear = false;
    //         playerLastPos = Vector3.zero;
    //         agent.SetDestination(WP[currentWP].position);
    //         if (agent.remainingDistance <= agent.stoppingDistance) {
    //             if(timeWait <= 0) {
    //                 NextWp();
    //                 Move(speedWalk);
    //                 timeWait = startWaitTime;
    //             } else {
    //                 Stop();
    //                 t_timeToRotate -= Time.deltaTime;
    //             }
    //         }
    //     }
    // }
    //
    // private void ChasePlayer() {
    //     t_playerNear = false;
    //     playerLastPos = Vector3.zero;
    //
    //     if(!t_playerFound) {
    //         Move(speedRun);
    //         agent.SetDestination(playerPos);
    //     }
    //     if (agent.remainingDistance <= agent.stoppingDistance)
    //     {
    //         if (timeWait <= 0 && !t_playerFound && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 6f)
    //         {
    //             t_IsPatrolling = true;
    //             t_playerNear = true;
    //             Move(speedWalk);
    //             t_timeToRotate = timeToRotate;
    //             timeWait = startWaitTime;
    //             agent.SetDestination(WP[currentWP].position);
    //         } else {
    //             if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 2.5f) {
    //                 Stop();
    //                 timeWait -= Time.deltaTime;
    //             }
    //         }
    //     }
    // }


}
