using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieType
{
    small,
    medium,
    big
}

public class Zombie
{
    public int HP;
    public int Attack;
    public float AttackRange;

    public Zombie(ZombieData zombieData)
    {
        HP = zombieData.HP;
        Attack = zombieData.Attack;
        AttackRange = zombieData.AttackRange;
    }
}

public class SpawnZombieData : MonoBehaviour
{
    [SerializeField] private ZombieData zombieData;
    public ZombieType zombieType;

    private void Update()
    {
        SpawnRandomZombie(zombieData);
    }

    private void SpawnRandomZombie(ZombieData zombieData)
    {
        
    }
}
