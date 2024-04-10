using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCamController : MonoBehaviour
{
    [SerializeField] private Transform viewPort;

    // ī�޶� ȸ�� ��� ���� ����
    [SerializeField] private float mouseSensitvity = 1f;
    [SerializeField] private int limitAngle = 60;            // ���콺�� ���� ȸ���� �����ϴ� ����
    private float verticalRot;                               // ���Ϸ� ȸ���ϱ� �� ��ġ�� �����صα� ���� ��
    private Vector2 mouseInput;

    [SerializeField] private bool inverseLook; // true�̸� ���콺 ���� ����, false�̸� ����
    // 1��Ī ī�޶� �÷��̾��� �ڽ����� �ͼӽ�Ű�� �ʰ� �÷��̾ ��������ϱ� ����
    // ī�޶� ������ �����´�.
    [SerializeField] private Camera firstCam;    // 1��Ī ī�޶� ���ӿ�����Ʈ�� ����ϱ� ���� ����
    // Start is called before the first frame update
    void Start()
    {
        // ���콺 Ŀ���� ���� �ϴ� ��Ʈ
        Cursor.visible = false;                        // �޴�, �ɼ� ��ư�� Ŭ�� �� ���콺 ��ư�� ���̰��Ѵ�.
        Cursor.lockState = CursorLockMode.Locked;      // ���콺�� ���� â ������ �������� ���ش�.
    }

    // Update is called once per frame
    void Update()
    {
        float inverseValue = inverseLook ? -1 : 1;   // inverseValue - inverseLook Bool���� ���� ���콺 ȸ���� ������ �� �ְ� �ȴ�.

        float rotationX = Input.GetAxisRaw("Mouse X");
        float rotationY = Input.GetAxisRaw("Mouse Y") * inverseValue;

        mouseInput = new Vector2(rotationX, rotationY) * mouseSensitvity;

        // �¿� ȸ��
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
            transform.rotation.eulerAngles.y + mouseInput.x ,
            transform.rotation.eulerAngles.z);                       // Quaternion.Euler �Լ� ( �Ű������� x,y,z�� �� ���� 0 ~360 ȸ�� ��ġ�� �Է��ϸ�) �� ��ġ��ŭ ȸ���� ���ʹϾ� ������ ��ȯ�Ѵ�.

        // ���� ȸ��

        verticalRot -= mouseInput.y;
        verticalRot = Mathf.Clamp(verticalRot, -limitAngle, limitAngle);             // ù��° ���ڷ� �� ���� �ּ� �ִ� ���� �Ѿ�� �ʰ� ���ش�.
             
        viewPort.rotation = Quaternion.Euler(verticalRot,
            viewPort.rotation.eulerAngles.y,
            viewPort.rotation.eulerAngles.z);


    }

    private void LateUpdate()             // playerController�� Update������ �÷��̾��� �̵��� ����. firstCamController ī�޶��� ȸ���� ����
    {
        firstCam.transform.position = viewPort.position;  // 1��Ī ī�޶��� ȸ���� �̵� ������ �ϴ� viewport�� position�� ��ġ�� �����ش�.
        firstCam.transform.rotation = viewPort.rotation;  

        // ���� ���������� ȸ���� �ε巴�� �����غ���
    }
}
