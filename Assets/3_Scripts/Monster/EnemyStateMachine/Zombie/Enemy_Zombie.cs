using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Zombie : Enemy
{
    #region State

    public ZombieIdleState IdleState { get; private set; }
    public ZombieMoveState moveState { get; private set; }

    public ZombieAttackState attackState { get; private set; }

    public ZombiePatrolState patrolState { get; private set; }
    #endregion

    public ZombieData zombieData;

    protected override void Awake()
    {
        base.Awake();

        IdleState = new ZombieIdleState(this, stateMachine, "Idle", this);
        moveState = new ZombieMoveState(this, stateMachine, "Walk", this);
        attackState = new ZombieAttackState(this, stateMachine, "Attack", this);
        patrolState = new ZombiePatrolState(this, stateMachine, "Walk", this);
        
        
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initilize(patrolState);
    }
    protected override void Update()
    {
        base.Update();
    }
    protected override void OnLoadComponets()
    {
        base.OnLoadComponets();
        HP=zombieData.HP;
        AttachPower = zombieData.Attack;
        AttackRange = zombieData.AttackRange;
        viewRange=zombieData.viewRange;
    }
}
