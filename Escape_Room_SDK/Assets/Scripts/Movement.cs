using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    [SerializeField] LayerMask groundLayer, playerLayer;

    //patrolling
    Vector3 destPoint;
    bool walkPointSet;
    [SerializeField] float walkRange;
    [SerializeField] float destinationRange = 2;

    //Chase
    [SerializeField] float sightRange;
    bool playerInSight;

    //Flee
    Vector3 direction;
    float magnitudeDirection;
    Vector3 normalizedDirection;

    //Draw Gizmo
    [SerializeField] bool drawGizmo;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        if (!playerInSight)
        {
            Patrol();
        }
        else
        {
            Flee();
        }
        

    }


    private void OnDrawGizmos()
    {
        if (drawGizmo)
        {
            Gizmos.DrawSphere(transform.position, sightRange);
        }
    }

    void Chase()
    {
        agent.SetDestination(player.transform.position);

    }


    void Patrol()
    {
        if (!walkPointSet)
        {
            SearchForDest();
        }
        if (walkPointSet)
        {
            agent.SetDestination(destPoint);

        }
        if (Vector3.Distance(transform.position, destPoint) < destinationRange)
        {
            walkPointSet = false;
        }
    }
    void SearchForDest()
    {
        float z = Random.Range(-walkRange, walkRange);
        float x = Random.Range(-walkRange, walkRange);
        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkPointSet = true;
        }
    }

    void  Flee()
    {
        direction = this.transform.position - player.transform.position;
        magnitudeDirection = direction.magnitude;
        normalizedDirection = direction.normalized;
        transform.position += normalizedDirection * magnitudeDirection * Time.deltaTime;
    }
}
