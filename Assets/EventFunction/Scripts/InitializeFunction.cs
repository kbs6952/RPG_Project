using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeFunction : MonoBehaviour
{
    // Debug.Log()

    private void Awake()
    {
        Debug.Log("Awake �Լ��� �����");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start �Լ��� �����");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable �Լ��� �����");
    }
}
