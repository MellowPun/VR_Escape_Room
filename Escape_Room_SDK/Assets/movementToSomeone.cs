using Oculus.Interaction.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class movementToSomeone : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    [SerializeField] LayerMask groundLayer, playerLayer;

    //paterolling
    Vector3 destPoint;
    bool walkPointSet;
    [SerializeField] float walkRange;

    //state change
    [SerializeField] float sightRange;
    bool playerInSight;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange,playerLayer);

        if (!playerInSight)
        {
            Patrol();
        }
        else
        {
            Chase();
        }
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
        if(Vector3.Distance(transform.position, destPoint) < 10)
        {
            walkPointSet = false;
        }
    }
    void SearchForDest()
    {
        float z = Random.Range(-walkRange,walkRange);
        float x = Random.Range(-walkRange,walkRange);
        destPoint = new Vector3(transform.position.x+x, transform.position.y, transform.position.z+z);

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkPointSet=true;
        }
    }

    void Chase()
    {
        agent.SetDestination(player.transform.position);
        Debug.Log("Something is here");
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position,sightRange);
    }
    
}
