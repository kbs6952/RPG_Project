using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;               // �÷��̾��� �̵� �ӵ�

    private Rigidbody rigidbody;                            // �÷��̾� ���� ������ ���� ������Ʈ
   
    [SerializeField] private GameObject powerIndicator;     // �Ŀ��� ���¸� Ȯ�ν��� �ֱ� ���� ���� ������Ʈ

    public bool IsPowerUp = false;

    [SerializeField] private float powerUpDuration = 1f;

    [SerializeField] private float pushPower = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0, v).normalized;

        rigidbody.AddForce(direction * moveSpeed);

        if (IsPowerUp)
        {
            StartCoroutine(PlayerPowerUp());
            /* Invoke("PowerUpTimeOver", powerUpDuration); */  // 7f : �Ŀ����� ���ӵǱ⸦ ���ϴ� �ð� -> ����ȭ ���Ѽ� �����͸� �����Ű�ų� ������ �� �ֽ��ϴ�.
        }

    }

    IEnumerator PlayerPowerUp()
    {
        IsPowerUp = true;
        powerIndicator.SetActive(true);

        yield return new WaitForSeconds(powerUpDuration);

        IsPowerUp = false;
        powerIndicator.SetActive(false);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Debug.Log($"{other.gameObject.name}");
            Destroy(other.gameObject);               // ������Ʈ�� �Ծ����Ƿ� �ش� ������Ʈ�� �ı��Ѵ�.
            IsPowerUp = true;                        // ������Ʈ�� �Ծ��� �� ����� ����
            powerIndicator.SetActive(true);          // ������Ʈ�� Ȱ��ȭ �Ǵ� �ڵ�
        }
    }

    void PowerUpTimeOver()
    {
        // �÷��̾��� �Ŀ��� ���°� �������� ǥ���� �� �ִ� �ڵ� 1���� �ۼ��غ�����. 
        IsPowerUp = false;
        powerIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ICollisionable col = collision.gameObject.GetComponent<ICollisionable>();

        if(col != null)
        {
            col.CollideWithPlayer(transform, 20);
        }
    }

}
