using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("Status")]
    public int HP;
    public int AttachPower;
    public float AttackRange;
    public float viewRange;

    public Rigidbody rigidbody;
    public Animator animator;

    protected virtual void Awake()
    {
        OnLoadComponets();
    }
    protected virtual void Update()
    {

    }
    protected virtual void OnLoadComponets()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    protected virtual void Start()
    {

    }
}
