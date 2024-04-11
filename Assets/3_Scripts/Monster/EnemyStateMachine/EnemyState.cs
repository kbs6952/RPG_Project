using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehaviour�� ����ϴ� EnemyŬ������ �����Ͽ� �����
/// Enemy�� ���¿� ���� ��� Enter, Exit, Update ��� ����
/// ������ State���� Base�� ����� Ŭ����
/// </summary>
public class EnemyState
{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemyBase;

    private string animName;

    protected float stateTimer;

    public EnemyState(Enemy _enemybase, EnemyStateMachine _stateMachine, string _animName)
    {
        enemyBase = _enemybase;
        stateMachine = _stateMachine;
        animName = _animName;
    }

    public virtual void Enter()
    {
        enemyBase.animator.CrossFade(animName, 0.2f);
    }
    public virtual void Exit()
    {

    }
    public virtual void Update()
    {
        stateTimer -= Time.time;
    }
}
