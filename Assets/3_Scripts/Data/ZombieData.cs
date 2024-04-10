using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ZombieData",menuName ="Data/ZombieData",order = int.MaxValue)]
public class ZombieData : ScriptableObject
{
    public string ZombieName;
    public int HP;
    public int Attack;
    public float AttackRange;
   
}
