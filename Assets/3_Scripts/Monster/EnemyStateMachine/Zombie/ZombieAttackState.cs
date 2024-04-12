using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackState : EnemyState
{
    Enemy_Zombie enemy;
    public ZombieAttackState(Enemy _enemybase, EnemyStateMachine _stateMachine, string _animName, Enemy_Zombie _enemy) : base(_enemybase, _stateMachine, _animName)
    {
        this.enemy=_enemy;
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Attack 상태 진입");

        if(enemy.IsAvailableAttack)
        {
            enemy.stateMachine.ChangeState(enemy.IdleState);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update() 
    {
        base.Update(); 
    }
}
