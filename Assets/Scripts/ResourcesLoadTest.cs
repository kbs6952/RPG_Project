using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesLoadTest : MonoBehaviour
{
    public Image testImage;    // Canvas/BG

    private int currentNumber;

    // Start is called before the first frame update
    void Start()
    {
        testImage.sprite = Resources.Load<Sprite>("Album/Album_01") as Sprite;     // Resouces.Load ȣ���ϴ� ������ -> Asset ������ �ȴ�. <T> ���׸� ����ȯ ����
    }


    private void Update()
    {
        // Ű���忡 �Է��ϴ� 1����. - �츮�� ȣ���ϴ� �ٹ� �̹����� 1���� ��Ī���Ѽ� ����ߴ�.

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeCurrentNumber();
            ChangeTestImageDynamic(GetCurrentImageNumber());
        }
    }

    private void ChangeCurrentNumber()
    {
        // Ŭ���� - ������ ��� 

        currentNumber = Random.Range(0, 3);  // 0 ~ 2 ���ڸ� ��ȯ�ϴ� �Լ�
    }

    private int GetCurrentImageNumber()
    {
        currentNumber = 0;

        return currentNumber;
    }


    public void ChangeTestImageDynamic(int imageNumber)
    {
        string path = "Album/Album_";

        path += imageNumber.ToString("D2"); // 01 Format����

        Debug.Log(path);

        testImage.sprite = Resources.Load<Sprite>(path) as Sprite; // Resources.Load�� �������� �̹��� ��ȯ
    }
}
