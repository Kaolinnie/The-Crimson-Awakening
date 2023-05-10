using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemryAi : MonoBehaviour
{
    public NavMeshAgent NAV;
    public Transform player;
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

    }
    private void ChasePlayer() {

    }
    private void AttackPlayer() {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInVisualRange = Physics.CheckSphere(transform.position, visualRange, WhatIsPlayer);
    }
}
