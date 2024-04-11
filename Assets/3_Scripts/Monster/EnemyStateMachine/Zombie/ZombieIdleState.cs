using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdleState : EnemyState
{
    Enemy_Zombie enemy;
    public ZombieIdleState(Enemy _enemybase, EnemyStateMachine _stateMachine, string _animName,Enemy_Zombie _enemy) : base(_enemybase, _stateMachine, _animName)
    {
        enemy = _enemy;
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("idle 상태 진입");
        stateTimer = enemy.idleTime;
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();

        if(stateTimer <= 0)
        {
            stateMachine.ChangeState();
        }
    }
}
