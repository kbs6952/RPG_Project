using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [Header("Enemy Stat")]
    public float idleTime;          // ide ���� �ð�
    public float moveTime;          // ���� �ð�
    public float chaseSpeed;        // ���� �ӵ�

    public EnemyStateMachine stateMachine {  get; private set; }

   protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
    }
    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }
    protected override void OnLoadComponets()
    {
        base.OnLoadComponets();
    }
    protected override void Start()
    {
        base.Start();
    }

}
