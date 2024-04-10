using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 스크립터블 오브젝트의 데이터를 저장하고 있는 적 클래스를 생성하는 클래스
/// zombie class를 spawn하는 기능
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
            zombie.transform.parent= transform;         // SpawnZombieData를 컴포넌트로 가지고 있는 오브젝트의 자식으로 좀비가 생성된다.
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
