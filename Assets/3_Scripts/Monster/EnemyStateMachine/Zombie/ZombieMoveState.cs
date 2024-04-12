using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMoveState : EnemyState
{
    Enemy_Zombie enemy;
    public ZombieMoveState(Enemy _enemybase, EnemyStateMachine _stateMachine, string _animName,Enemy_Zombie _enemy) : base(_enemybase, _stateMachine, _animName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Move 상태 진입");
        stateTimer = enemy.idleTime;
    }
    public override void Exit()
    {
        base.Exit();
        Debug.Log("Move 상태 종료");
        enemy.agent.ResetPath();
    }
    public override void Update()
    {
        base.Update();
        Transform target = enemy.SearchTarget();
        if(target)
        {
            enemy.agent.SetDestination(target.position);
        }
        else
        {
            stateMachine.ChangeState(enemy.IdleState);
        }
        if(enemy.IsAvailableAttack)
        {
            stateMachine.ChangeState(enemy.attackState);
        }
    }
}
