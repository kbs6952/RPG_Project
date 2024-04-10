using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    // �÷��̾��� ����( ���߾� )
    // ������ �������� �ȵǴ� ���� -> ���߾��� ��ġ�� ����ϴ� ��.
    // ���� �ൿ�� ����� �˰��� AI �ൿ ���� 

    public GameObject centerPoint;
    public float enemyMoveSpeed;
    public Rigidbody rigidbody;

    private Vector3 targetDirection;

    [SerializeField] private float pushPower;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        // ������ �ѹ��� �����ǰ�. Enemy �� �������θ� �����̱� ������ (�Ѿ� ���ϱ�)
        //targetDirection = (playerObject.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        // Enemy�� ���߾��� ��ġ�� ����ؼ� �̵��ϴ� ����
        targetDirection = (centerPoint.transform.position - transform.position).normalized;
        rigidbody.AddForce(targetDirection * enemyMoveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DestoryZone"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("���� �浹�Ͽ���!");
            // ���� �浹���� �� ���� ������ �� �� ���󰡰� ���ִ� ����� �߰��غ���.

            Vector3 powerVector = (transform.position - collision.transform.position).normalized;    // �浹(�÷��̾�)�� Enemy ������ ���Ѵ� ( normalized�� ���� ���� ũ�⸦ �� ���⸸ ���� �� �ִ�.)
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();               // Enemy�� ���� �ִ� Rigidbody�� �����ؼ� Enemy�� ���� ȿ���� ������ �� �ִ�.
            enemyRigidbody.AddForce(powerVector * pushPower, ForceMode.Impulse);                     // EnemyRigidbody. AddForce �Լ��� �̿��ؼ� Enemy�� �浹�� �� �� ũ�� ���󰡵��� �����Ͽ���.

        }
    }
}
