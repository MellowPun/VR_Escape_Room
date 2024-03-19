using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class StateManagerMonsters : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    public GameObject player;
    public LayerMask groundLayer, playerLayer;
    public float walkRange = 100;
    public float destinationRange = 2;
    Animator animator;

    public MonsterBaseState currentState;
    public MonsterChaseState chaseState = new MonsterChaseState();
    public MonsterFleeState fleeState = new MonsterFleeState();
    public MonsterPatrolState patrolState = new MonsterPatrolState();


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        currentState = patrolState;

        currentState.EnterState(this);

    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void ChaseState()
    {
        currentState= chaseState;
        currentState. EnterState(this);
    }
    public void FleeState()
    {
        currentState = fleeState;
        currentState.EnterState(this);
    }
    public void PatrolState()
    {
        currentState = patrolState;
        currentState.EnterState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("We colliding");
        Debug.Log(other.gameObject.name);
        currentState.OnCollisionEnter(this, other);
    }
    
}
