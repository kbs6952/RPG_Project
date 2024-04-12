using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ZombiePatrolState : EnemyState
{
    Enemy_Zombie enemy;
    public ZombiePatrolState(Enemy _enemybase, EnemyStateMachine _stateMachine, string _animName, Enemy_Zombie _enemy) : base(_enemybase, _stateMachine, _animName)
    {
        enemy = _enemy;
    }
    public override void Enter()
    {
        base.Enter();

        if(enemy.targetWayPoint==null)
        {
            enemy.FindIndexWayPoint();
        }
        if(enemy.targetWayPoint)
        {
            enemy.agent.SetDestination(enemy.targetWayPoint.position);
        }
        Debug.Log("패트롤 상태 진입");


    }
    public override void Exit() 
    {
        base.Exit();
        Debug.Log("패트롤 상태 종료");
    }
    public override void Update()
    { 
        base.Update();

        Transform target=enemy.SearchTarget();

        if(target)
        {
            if(enemy.IsAvailableAttack)
            {
                stateMachine.ChangeState(enemy.attackState);
            }
            else
            {
                stateMachine.ChangeState(enemy.moveState);
            }
        }
        else
        {
            if(!enemy.CheckRemainDistance())
            {
                Transform nextDestination = enemy.FindIndexWayPoint();
                enemy.agent.SetDestination(nextDestination.position);
                stateMachine.ChangeState(enemy.IdleState);
            }
        }
    }
}
