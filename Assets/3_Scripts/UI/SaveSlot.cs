using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;


public enum SaveGameSlot
{
    _00,
    _01,
    _02,
    _03,
    No_Slot
}

public class SaveSlot : MonoBehaviour
{

    [Header("���� ���� ����")]
    public SaveGameSlot saveGameSlot;
    [SerializeField] TMP_Text playername;
    [SerializeField] TMP_Text playTime;
    private string userName;

    [Header("�÷��� �ð� ����")]
    private float timeValue;
    private int min;
    private int sec;

    [Header("������ �ڵ鷯")]
    private DataHandler dataHandler;
    private GameData gameData;

    private void OnEnable()
    {
        // �ε� ��ư �׷��� Ȱ��ȭ ���� �� ���� ��Ű�� �Լ�
        // ������ �ڵ鷯�� ����Ͽ� �ܺο� ����� ������ �����ϸ� �����͸� �����ϰ�, �׷��� ������ �⺻ ���� ����Ѵ�.
        LoadSavedSlotData();
    }

    private void LoadSavedSlotData()   // Slot�� ������ ������ �а� ����Ѵ�.
    {
        string mySlotName = SaveManager.Instance.fileName + saveGameSlot.ToString() + ".txt";
        dataHandler = new DataHandler(Application.persistentDataPath, mySlotName);        // SaveGameSlot ������ ���� ���� ����Ǵ� ���� �̸��� ����ȴ�.

        if (dataHandler.CheckFileExists(Application.persistentDataPath, mySlotName))
        {
            // �ش� �����Ϳ� �ִ� gameData�� gameData�� �����ϰ� �����͸� ������� �ش�.
            gameData = dataHandler.DataLoad();
            LoadData();
        }
    }

    public void LoadGameData()
    {
        SaveManager.Instance.ChangeSaveFileNameBySelectSlot(saveGameSlot);

        // ���� �ε� �ϴ� ���
        LoadingUI.LoadScene("CameraSettingScene");
    }

    public void DeleteGameData()
    {
        dataHandler.DataDelete();

        playername.text = "No Data";
        playTime.text = "00 : 00";

        gameObject.SetActive(false);
    }

    private void LoadData()
    {
        playername.text = gameData.playerName;
        if(userName == "")
        {
            playername.text = "�̸��� ����";
        }

        timeValue = gameData.timeValue;

        min = (int)timeValue / 60;
        sec = ((int)(timeValue - min) % 60);

        playTime.text = string.Format("{0:D2} : {1:D2}", min, sec);
    }


    private void Reset()
    {
        playername = transform.Find("CharacterName").GetComponent<TMP_Text>();
        playTime = transform.Find("PlayTimeText").GetComponent<TMP_Text>();
    }
}
