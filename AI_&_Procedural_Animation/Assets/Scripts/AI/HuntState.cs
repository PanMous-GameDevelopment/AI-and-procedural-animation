using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HuntState : State // Inherits from State.
{
    [Header("Other states")]
    public RoamState roamState; // A reference to the RoamState script.
    public AttackState attackState; // A reference to the AttackState script.

    [Header("Enemy Stats")]
    public GameObject enemy;
    public UnityEngine.AI.NavMeshAgent agent;
    public Transform player;
    public float detectionRange, attackRange;
    public bool playerInDetectionRange, playerInAttackRange;
    public LayerMask Player;

    void Start()
    {
        agent = enemy.GetComponent<UnityEngine.AI.NavMeshAgent>(); // Getting the navmesh.
    }

    public override State RunCurrentState()
    {
        agent.SetDestination(player.position); // Chase the player.

        // Sets the player in detection and attack range variables based on the detection and attack range AND the player position.
        playerInDetectionRange = Physics.CheckSphere(transform.position, detectionRange, Player);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, Player);
    
        if (playerInDetectionRange && playerInAttackRange) // If the player is in detection range and also in attack range then return the attack state as the current state.
        {
            return attackState; 
        } 
        else if (!playerInDetectionRange && !playerInAttackRange) // Else if the player is NOT in detection range and also NOT in attack range then return the roam state as the current state.
        {
            return roamState; 
        }
        else // Otherwise remain in this state.
        {
            Debug.Log("Player spotted. The Hunt State is on.");
            return this; 
        }
    }
}
