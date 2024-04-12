using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
    [Header("Enemy Stat")]
    public float idleTime;          // ide ���� �ð�
    public float moveTime;          // ���� �ð�
    public float chaseSpeed;        // ���� �ӵ�

    public EnemyStateMachine stateMachine { get; private set; }
   

    public NavMeshAgent agent;

    [Header("Search Target")]
    public LayerMask targetMask;        // Ÿ�� ���� ���̾� ����ũ
    public Transform target;
    public float viewRadius;            // Ž�� ����

    [Header("Patrol")]
    [SerializeField] private Transform[] wayPoints;         // Ž���� ��ġ ����
    [HideInInspector]  public Transform targetWayPoint = null;
    private int wayPointIndex = 0;
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
        agent = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// true �̸� ���� �Ÿ��� �ִ�. false�̸� ���� �Ÿ��� �����Ƿ� ���� ����� ã�´�.
    /// </summary>
    /// <returns></returns>
    public bool CheckRemainDistance()
    {
        if ((wayPoints[wayPointIndex].transform.position - transform.position).sqrMagnitude < 0.1)
        {
            if (wayPointIndex < wayPoints.Length - 1)
                wayPointIndex++;
            else
                wayPointIndex = 0;
            return false;
        }
        return true;
    }
    public Transform FindIndexWayPoint()
    {
        targetWayPoint = null;
        if(wayPoints.Length>0)
        {
            targetWayPoint = wayPoints[wayPointIndex];
        }
        return targetWayPoint;
    }
            
        
    



    public bool IsAvailableAttack()
    {
        get
          {
            if (!target)
            {
                return false;
            }
            if (target.position - transform.position).sqrMagnitude < AttackRange)
                   { 
                return true; 
            }
            else
            { 
                return false; 
            }
        }
    }
public Transform SearchTarget()
{
    target = null;
        Collider[] targetInViewRadus = Physics.OverlapSphere(transform.position);
}
    protected override void Start()
    {
        base.Start();
    }

}




