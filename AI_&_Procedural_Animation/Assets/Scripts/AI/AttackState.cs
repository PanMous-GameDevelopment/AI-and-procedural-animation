using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : State // Inherits from State.
{
    [Header("Other states")]
    public RoamState roamState; // A reference to the RoamState script.
    public HuntState huntState; // A reference to the HuntState script.

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
      
        if (playerInDetectionRange && !playerInAttackRange) // Checks if the player is in detection range but not in attack range. Then returns the hunt state as the current state.
        {
            return huntState; 
        } 
        else if (!playerInDetectionRange && !playerInAttackRange) // Checks if the player is not in detection range and also not in attack range. Then returns the roam state as the current state.
        {
            return roamState; 
        }
        else // In any other case the enemy is in the attack state and performs the attack action.
        {
            Debug.Log("Player is close. The Attack State is on.");
            return this; 
        }
    }
}
