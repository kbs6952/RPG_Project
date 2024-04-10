using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ũ���ͺ� ������Ʈ�� �����͸� �����ϰ� �ִ� �� Ŭ������ �����ϴ� Ŭ����
/// zombie class�� spawn�ϴ� ���
/// </summary>
public enum ZombieType
{
    small,
    medium,
    big
}
public class SpawnZombieData : MonoBehaviour
{
    [SerializeField] private List<ZombieData> zombieDatas;
    [SerializeField] GameObject zombiePrefab;
    

    private void Start()
    {
        for(int i=0; i<zombieDatas.Count; i++)
        {
            var zombie = SpawnZombie((ZombieType)i);
            zombie.transform.parent= transform;         // SpawnZombieData�� ������Ʈ�� ������ �ִ� ������Ʈ�� �ڽ����� ���� �����ȴ�.
        }
    }


    private Zombie SpawnZombie(ZombieType zombieType)
    {
        Zombie newZombie = Instantiate(zombiePrefab).GetComponent<Zombie>();
        newZombie.zombieData = zombieDatas[(int)zombieType];
        newZombie.name = newZombie.zombieData.ZombieName;
        newZombie.OnLoadComponents();

        return newZombie;
    }
}
