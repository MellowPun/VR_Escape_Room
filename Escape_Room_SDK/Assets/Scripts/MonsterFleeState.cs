using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class MonsterFleeState : MonsterBaseState
{
    Vector3 direction;
    float magnitudeDirection;
    Vector3 normalizedDirection;
    
    float timer;
    float runningSeconds = 7;

    public override void EnterState(StateManagerMonsters monster)
    {
        Debug.Log("We fleeing");
    }
    public override void UpdateState(StateManagerMonsters monster)
    {

        GameObject _player = monster.player;
        direction = monster.transform.position - _player.transform.position;
        magnitudeDirection = direction.magnitude;
        normalizedDirection = direction.normalized;
        monster.transform.position += normalizedDirection * magnitudeDirection * Time.deltaTime;
        timer += Time.deltaTime;
        if(timer > runningSeconds ) 
        {
            monster.PatrolState();
        }

    }
    public override void OnCollisionEnter(StateManagerMonsters monster, Collider collision)
    {

    }
}
