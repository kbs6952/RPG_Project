using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ��ǥ ������ �����ϴ� Ŭ����. index�� �ִ밡 �Ǹ� 0���� �ʱ�ȭ�Ѵ�.
/// </summary>

public class SimplePatrol : MonoBehaviour
{
    [SerializeField] private Transform[] paths;         // �ν����� â���� ��������� �Ѵ�.
    private int currentPath = 0;
    private float moveSpeed = 3.0f;

    private void Update()
    {
        Vector3 direction = (paths[currentPath].position - transform.position).normalized;

        transform.position = transform.position + direction * moveSpeed * Time.deltaTime;

        if ((paths[currentPath].position-transform.position).sqrMagnitude<0.1f)     // Vector3.Distance()���� ������.
        {
            if (currentPath < paths.Length - 1)
                currentPath++;
            else
                currentPath = 0;

            
        }
    }
}
