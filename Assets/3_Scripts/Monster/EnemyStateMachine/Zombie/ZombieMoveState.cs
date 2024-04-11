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
    }
    public override void Update()
    {
        base.Update();

        if (stateTimer <= 0)
        {
            stateMachine.ChangeState();
        }
    }
}
