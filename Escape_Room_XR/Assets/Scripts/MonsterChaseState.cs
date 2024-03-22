using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene(1);
            DataSaving data = SaveSystem.LoadPlayer();
            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            other.transform.position = position;
        }
    }
}
