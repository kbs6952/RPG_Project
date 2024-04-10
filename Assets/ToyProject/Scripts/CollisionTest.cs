using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour, ICollisionable
{
    private Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }


    public void CollideWithPlayer(Transform player, float _pushPower)
    {
        Vector3 awayVector = (transform.position - player.position).normalized;  // ���� ���� - ����� ��ġ(Player) 

        rigid.AddForce(awayVector * _pushPower, ForceMode.Impulse);          // Player���� ���󰡴� ���� �Ű������� ���� 
    }

    
}
