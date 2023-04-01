using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoamState : State // Inherits from State.
{
    [Header("Other states")]
    public HuntState huntState; // A reference to the HuntState script.

    [Header("Enemy Stats")]
    public GameObject enemy;
    public UnityEngine.AI.NavMeshAgent agent;
    public float range;
    public Transform centerPoint;
    public float detectionRange, attackRange;
    public bool playerInDetectionRange, playerInAttackRange;
    public LayerMask Player;

    void Start()
    {
        agent = enemy.GetComponent<UnityEngine.AI.NavMeshAgent>(); // Getting the navmesh.      
    }

    // Sets a random point on the map based on another point acting as a center (usually the enemy's current position) and a range variable.
    // It finds a point around that center inside the set range.
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range; // Sets a random point inside a sphere based on a center point and a range variable.
        UnityEngine.AI.NavMeshHit hit;
        if (UnityEngine.AI.NavMesh.SamplePosition(randomPoint, out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }

    public override State RunCurrentState()
    {
        // Checks if the distance between the current position of the NavMeshAgent and its destination is less than or equal to the stoppingDistance of the NavMeshAgent.
        if (agent.remainingDistance <= agent.stoppingDistance) 
        {
            Vector3 point;
            if (RandomPoint(centerPoint.position, range, out point)) // Sets a new random destination for the enemy.
                agent.SetDestination(point);
        }

        // Sets the player in detection and attack range variables based on the detection and attack range AND the player position.
        playerInDetectionRange = Physics.CheckSphere(transform.position, detectionRange, Player);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, Player);
        
        if (playerInDetectionRange && !playerInAttackRange) // If the player is in detection range and NOT in attack range then returns the hunt state as the current state.
        {
            return huntState;
        }
        else // Otherwise remain in this state.
        {
            return this; 
        }
    }
}
