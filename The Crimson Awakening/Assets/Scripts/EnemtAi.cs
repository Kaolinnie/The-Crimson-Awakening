using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemryAi : MonoBehaviour
{
    public NavMeshAgent NAV;
    public Transform player;
    public float health;
    public GameObject projectile;
    public LayerMask WhatIsGround, WhatIsPlayer;
    //walk point partrol variables
    public Vector3 WP;
    bool WPset;
    public float WPRange;
    //Attack variables
    public float timeBetweenAttack;
    bool Attacked;
    //
    public float attackRange, visualRange;
    public bool playerInVisualRange, playerInAttackRange; 

    public void Awake() {
        player = GameObject.Find("Mira Variant").transform;
        NAV = GetComponent<NavMeshAgent>();
    }
    
    private void Patrolling() {
        if (!WPset) {
            FindWWP();
        } 
        if (WPset) {
            NAV.SetDestination(WP);
        }
        Vector3 distanceToWP = transform.position - WP;

        if(distanceToWP.magnitude < 1f) {
            WPset = false;
        }
    }

    private void FindWWP()
    {
        float WPZ = UnityEngine.Random.Range(-WPRange, WPRange);
        float WPX = UnityEngine.Random.Range(-WPRange, WPRange);

        WP = new Vector3(transform.position.x + WPX, transform.position.y, transform.position.z + WPZ);

        if (Physics.Raycast(WP, -transform.up, 2f, WhatIsGround)) {
            WPset = true;
        }
    }

    private void ChasePlayer() {
        NAV.SetDestination(player.position);
    }

    // private void AttackPlayer() {
    //     NAV.SetDestination(transform.position);
    //     transform.LookAt(player);

    //     if (!Attacked) {
    //         Rigidbody  rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
    //         rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
    //         rb.AddForce(transform.up * 8f, ForceMode.Impulse);
    //         Attacked = true;
    //         Invoke(nameof(ResetAttack), timeBetweenAttack);
    //     }
    // }

    private void ResetAttack() {
        Attacked = false;
    }

    private void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0) Invoke(nameof(DestroyEnemy), .5f);
    }

    private void DestroyEnemy() {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInVisualRange = Physics.CheckSphere(transform.position, visualRange, WhatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsPlayer);

        if (!playerInVisualRange && !playerInAttackRange) {
            Patrolling();
        }
        if (playerInVisualRange && !playerInAttackRange) {
            ChasePlayer();
        }
        // if  (playerInAttackRange && playerInVisualRange) {
        //     AttackPlayer();
        // }
    }
}
