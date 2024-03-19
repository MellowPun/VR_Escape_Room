using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MonsterPatrolState : MonsterBaseState
{
    bool walkPointSet;
    Vector3 destPoint;
    bool playerInSight;
    float sightRange = 20;


    public override void EnterState(StateManagerMonsters monster)
    {
        Debug.Log("We patrolling");

    }
    public override void UpdateState(StateManagerMonsters monster) 
    {
        
        NavMeshAgent agent = monster.GetComponent<NavMeshAgent>();
        LayerMask playerLayer = monster.playerLayer;    

        float destinationRange = monster.destinationRange;
        playerInSight = Physics.CheckSphere(monster.transform.position, sightRange,playerLayer);
        if (!playerInSight)
        {
            if (!walkPointSet)
            {
                SearchForDest(monster);
            }
            if (walkPointSet)
            {
                agent.SetDestination(destPoint);

            }
            if (Vector3.Distance(monster.transform.position, destPoint) < destinationRange)
            {
                walkPointSet = false;
            }
        }
        else
        {
            monster.ChaseState();
        }

        
    }

    public override void OnCollisionEnter(StateManagerMonsters monster, Collider collision)
    {
        GameObject other = collision.gameObject;
        

        if (other.CompareTag("LightSource"))
        {
            monster.FleeState();    
        }
        if (other.CompareTag("Player"))
        {
            Debug.Log("You lose");
        }
    }
    void SearchForDest(StateManagerMonsters monster)
    {
        float walkRange = monster.walkRange;
        LayerMask groundLayer = monster.groundLayer;


        float z = Random.Range(-walkRange, walkRange);
        float x = Random.Range(-walkRange, walkRange);
        destPoint = new Vector3(monster.transform.position.x + x, monster.transform.position.y, monster.transform.position.z + z);

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkPointSet = true;
        }
    }
}
