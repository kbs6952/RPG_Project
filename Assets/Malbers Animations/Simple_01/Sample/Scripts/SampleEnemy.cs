using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollisionable
{
    public void CollideWithPlayer(Transform player, float _pushPower); // Player(��)�� �ε��� ��ü�� Ư�� �������� ���󰡴� ����� �������̽� �����ϰڴ�.
}


public class SampleEnemy : MonoBehaviour, ICollisionable
{
    // �÷��̾��� ����( ���߾� )
    // ������ �������� �ȵǴ� ���� -> ���߾��� ��ġ�� ����ϴ� ��.
    // ���� �ൿ�� ����� �˰��� AI �ൿ ���� 

    [SerializeField] private GameObject centerPoint;
    [SerializeField] private float enemyMoveSpeed;
    private Rigidbody rigidbody;
    private Vector3 targetDirection;

    [SerializeField] private float pushPower;

    public GameObject CenterPoint
    { 
        get => centerPoint;
        set => centerPoint = value;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        centerPoint = GameObject.Find("CenterPivot");
        // ������ �ѹ��� �����ǰ�. Enemy �� �������θ� �����̱� ������ (�Ѿ� ���ϱ�)
        //targetDirection = (playerObject.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        // Enemy�� ���߾��� ��ġ�� ����ؼ� �̵��ϴ� ����
        targetDirection = (centerPoint.transform.position - transform.position).normalized;
        rigidbody.AddForce(targetDirection * enemyMoveSpeed, ForceMode.Force);

        if(transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
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
        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    // ���� �浹���� �� ���� ������ �� �� ���󰡰� ���ִ� ����� �߰��غ���.

        //    Vector3 powerVector = (transform.position - collision.transform.position).normalized;    // �浹(�÷��̾�)�� Enemy ������ ���Ѵ� ( normalized�� ���� ���� ũ�⸦ �� ���⸸ ���� �� �ִ�.)

        //    rigidbody.AddForce(powerVector * pushPower, ForceMode.Impulse);                         // EnemyRigidbody. AddForce �Լ��� �̿��ؼ� Enemy�� �浹�� �� �� ũ�� ���󰡵��� �����Ͽ���.

        //}
    }

    public void CollideWithPlayer(Transform player, float _pushPower)
    {
        // �÷��̾�� �浹���� �� ��ü�� ���󰡴� ������ �ۼ����ָ� �˴ϴ�.
        Debug.Log("Collide�������̽��� ȣ���!");

        Vector3 awayVector = (transform.position - player.position).normalized;  // ���� ���� - ����� ��ġ(Player) 

        rigidbody.AddForce(awayVector * _pushPower, ForceMode.Impulse);          // Player���� ���󰡴� ���� �Ű������� ���� 

    }
}
