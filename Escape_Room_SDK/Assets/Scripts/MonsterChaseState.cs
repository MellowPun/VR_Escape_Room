using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MonsterChaseState : MonsterBaseState
{
    

    public override void EnterState(StateManagerMonsters monster)
    {
        Debug.Log("We chasing");
    }
    public override void UpdateState(StateManagerMonsters monster)
    {
        NavMeshAgent agent = monster.GetComponent<NavMeshAgent>();
        GameObject _player = monster.player;
        agent.SetDestination(_player.transform.position);
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
}
