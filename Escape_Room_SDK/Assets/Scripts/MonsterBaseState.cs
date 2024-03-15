using UnityEngine;

public abstract class MonsterBaseState 
{
    public abstract void EnterState(StateManagerMonsters monster);
    public abstract void UpdateState(StateManagerMonsters monster);
    public abstract void OnCollisionEnter(StateManagerMonsters monster, Collider collision);
}
