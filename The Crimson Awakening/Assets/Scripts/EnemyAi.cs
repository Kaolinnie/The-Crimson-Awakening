using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent NAV;
    public float startWaitTime = 4;
    public float timeToRotate = 2;
    public float speedWalk = 6;
    public float speedRun = 9;

    public float viewRadius = 15;
    public float viewAngle = 90;
    public LayerMask PM;
    public LayerMask OM;
    public float meshRes = 1f;
    public int edgeIterations = 4;
    public float edgeDistance = 0.5f;

    public Transform[] WP;
    int currentWP;
    Vector3 playerLastPos = Vector3.zero;
    Vector3 playerPos;

    float timeWait, t_timeToRotate;

    bool t_playerInRange, t_playerNear, t_IsPatrolling, t_playerFound;


    // Start is called before the first frame update
    void Start()
    {
        playerPos = Vector3.zero;
        t_IsPatrolling = true;
        t_playerFound = false;
        t_playerInRange = false;
        timeWait = startWaitTime;
        t_timeToRotate = timeToRotate;
        currentWP = 0;
        NAV = GetComponent<NavMeshAgent>();
        
        NAV.isStopped = false;
        NAV.speed = speedWalk;
        NAV.SetDestination(WP[currentWP].position);

        if (currentWP < 0 || currentWP >= WP.Length) {
            currentWP = 0;
        }


    }

    void Move(float speed) {
        NAV.isStopped = false;
        NAV.speed = speed;
    }

    void Stop() {
        NAV.isStopped = true;
        NAV.speed = 0;
    }

    void NextWp() {
        currentWP = (currentWP + 1) % WP.Length;
        NAV.SetDestination(WP[currentWP].position);
    }

    void PlayerFound () {
        t_playerFound = true;
    }

    void LookingForPlayer(Vector3 player) {
        NAV.SetDestination(player);
        if(Vector3.Distance(transform.position, player) <= 0.3) {
            if(timeWait <= 0) {
                t_playerNear = false;
                Move(speedWalk);
                NAV.SetDestination(WP[currentWP].position);
                timeWait = startWaitTime;
                timeToRotate = t_timeToRotate;
            } else {
                Stop();
                timeWait -= Time.deltaTime;
            }
        }
    }
    
    //pin = player in range
    void EnvironmentView() {
        Collider[] PIN = Physics.OverlapSphere(transform.position, viewRadius, PM);
        for(int i = 0; i < PIN.Length; i++) {
            Transform player = PIN[i].transform;
            Vector3 playerDirection = (player.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, playerDirection)< viewAngle / 2) {
                float playerDistance = Vector3.Distance(transform.position, player.position);
                if(!Physics.Raycast(transform.position, playerDirection, playerDistance, OM)) {
                    t_playerInRange = true;
                    t_IsPatrolling = true;
                } else {
                    t_playerInRange = false;
                }
            }

            if(Vector3.Distance(transform.position, player.position) > viewRadius) {
                t_playerInRange = false;
            }

            if(t_playerInRange) {
                playerPos = player.transform.position;
            }
        }
        
    } 

    private void Patrolling() {
        if (t_playerNear) {
            if (timeToRotate <= 0) {
                Move(speedWalk);
                LookingForPlayer(playerLastPos);
            } else {
                Stop();
                t_timeToRotate -= Time.deltaTime;
            }
        } else {
            t_playerNear = false;
            playerLastPos = Vector3.zero;
            NAV.SetDestination(WP[currentWP].position);
            if (NAV.remainingDistance <= NAV.stoppingDistance) {
                if(timeWait <= 0) {
                    NextWp();
                    Move(speedWalk);
                    timeWait = startWaitTime;
                } else {
                    Stop();
                    t_timeToRotate -= Time.deltaTime;
                }
            }
        }
    }

    private void ChasePlayer() {
        t_playerNear = false;
        playerLastPos = Vector3.zero;

        if(!t_playerFound) {
            Move(speedRun);
            NAV.SetDestination(playerPos);
        }
        if (NAV.remainingDistance <= NAV.stoppingDistance)
        {
            if (timeWait <= 0 && !t_playerFound && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 6f)
            {
                t_IsPatrolling = true;
                t_playerNear = true;
                Move(speedWalk);
                t_timeToRotate = timeToRotate;
                timeWait = startWaitTime;
                NAV.SetDestination(WP[currentWP].position);
            } else {
                if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 2.5f) {
                    Stop();
                    timeWait -= Time.deltaTime;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!t_IsPatrolling) {
            ChasePlayer();
        } else {
            Patrolling();
        }
    }
}
