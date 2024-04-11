using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [Header("Enemy Stat")]
    public float idleTime;          // ide 상태 시간
    public float moveTime;          // 추적 시간
    public float chaseSpeed;        // 추적 속도

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
