using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleZombieController : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent agent;

    [Header("좀비가 쫓아갈 대상")]
    public Transform target;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        TraceTarget(target.position);
    }

    /// <summary>
    /// naMeshAgent를 이용하여 타겟을 추적하는 함수
    /// </summary>
    /// <param name="des"></param>
    private void TraceTarget(Vector3 des)
    {
        agent.SetDestination(des);
    }
}
