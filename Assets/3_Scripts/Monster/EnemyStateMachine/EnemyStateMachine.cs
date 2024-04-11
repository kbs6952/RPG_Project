using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// EnemyState�� ���� ���¸� ��ȯ, �ٸ� ���·� ��ȯ�ϴ� ����� �ϴ� Ŭ����, EnemyState Ŭ������ �����Ͽ� ���
/// </summary>
public class EnemyStateMachine
{
    public EnemyState currentState {  get; private set; }

    public void Initilize(EnemyState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }
    public void ChangeState(EnemyState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
