using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  싱클톤 패턴을 구현해서 반복을 없애주기 위한 클래스
///  인스턴스를 생성하고 게임 실행중에 파괴되지 않도록 보장
/// </summary>

public class SingletonMono<T> : MonoBehaviour where T : Component
{
    private static T instance;
    public static T Instance => instance;

    public static T GetOrCreateInstance()
    {
        if (instance == null)
        {
            instance = FindAnyObjectByType(typeof(T)) as T;

            if(instance==null)
            {
                GameObject newGameObject=new GameObject(typeof(T).Name,typeof(T));

                instance = newGameObject.GetComponent<T>();
            }
            return instance;
        }
        return instance;
    }
    protected virtual void Awake()
    {
            instance = this as T;
        if (Application.isPlaying == true)
        {
            DontDestroyOnLoad(gameObject);
        }
        

    }
}
