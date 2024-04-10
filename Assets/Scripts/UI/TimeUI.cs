using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour, ISaveManager
{
    [SerializeField] TMP_Text timeText;         // �ð��� ǥ���� �ؽ�Ʈ

    private float timeValue;                    // �ð� ������ ������ ����  Time.deltaTime ���� ����  
    private int min;                            // ��
    private int sec;                            // ��


    private void Update()
    {
        // �ð��� ������Ű�� text�� ��½�Ű�� ���
        SetTimeUI();
    }

    private void SetTimeUI()
    {
        timeValue += Time.deltaTime;

        min = (int)timeValue / 60;
        sec = ((int)(timeValue - min) % 60);

        timeText.text = string.Format("{0:D2} : {1:D2}", min, sec);
    }

    public void LoadData(GameData gameData)
    {
        timeValue = gameData.timeValue;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.timeValue = timeValue;
    }
}
