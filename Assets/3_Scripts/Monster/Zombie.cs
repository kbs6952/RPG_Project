using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable ������Ʈ�� �����͸� �޾ƿͼ� �����ϱ� ���� Ŭ����
/// </summary>
public class Zombie : MonoBehaviour
{
    public ZombieData zombieData;

    public string ZombieName;
    public int HP;
    public int Attack;
    public float AttackRange;

    public void OnLoadComponents()
    {
        ZombieName = zombieData.ZombieName;
        HP = zombieData.HP;
        Attack = zombieData.Attack;
        AttackRange = zombieData.AttackRange;
    }
}
