using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class SaveManager : SingletonMono<SaveManager>
{
    public static SaveManager Instance;  // �̱��� ������ ���� �ν��Ͻ� ����
    
    
    // Singleton Pattern : �ν��Ͻ��� ���� ��� �ν��Ͻ��� �����ϰ�, �̹� ������ ��� �ν��Ͻ��� ��ȯ

    DataHandler dataHandler;
    GameData gameData;                   // �÷��̾��� ������ ������ Ŭ����
    List<ISaveManager> saveManagers;     // ���̾��Űâ�� �ִ� ISaveManager�� ����ϴ� Ŭ������ ������ ����Ʈ

    [Header("������ ������ ���� ����")]
    public string originName;
    public string fileName;
    public SaveGameSlot nowSlot;         // ���� ���õ� ������ �����ϴ� ����

    protected override void Awake()         // ctrl + M + M 
    {
        base.Awake();
        originName = fileName;
    }

    public void NewGame()
    {
        gameData = new GameData();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneloaded;    // �ݹ����� ȣ���ϰ� �Լ��� ����Ѵ�.
    }

    private void OnSceneloaded(Scene scene, LoadSceneMode mode) // �Ű� ������ scene, Sceneȣ�� ����� �Ű� ������ �ۼ��� ����� �Ѵ�.
    {
        dataHandler = new DataHandler(Application.persistentDataPath, fileName);  //  ���� : �÷����� ������� �����͸� ���� ������ �� �ִ�. ���� : Ư�� �÷����� ��쿡�� ����� �����͸� Ȯ���� �� ����.
        saveManagers = FindAllSaveManagers();                                     // ���̾��Űâ�� �ִ� ISaveManager�� ����ϴ� Ŭ������ ã�Ƽ� ����Ʈ�� �����Ѵ�.
        LoadGame();
    }

    public void ChangeSaveFileNameBySelectSlot(SaveGameSlot slot)   // SaveSlot Ŭ�������� ȣ���ϴ� �Լ�
    {
        nowSlot = slot;

        fileName += slot.ToString() + ".txt";
    }

    public void SaveGame()
    {
        // 1. ������ �����͸� �� �Լ��� ȣ���� �ڿ� gameData�� �����Ѵ�.
        foreach(var saveManager in saveManagers)
        {
            saveManager.SaveData(ref gameData);
        }

        // 2. ������ gameData�� �ܺ� ������ �����Ų��.
        dataHandler.DataSave(gameData);
        Debug.Log("������ ����Ǿ����ϴ�.");
    }

    public void LoadGame()
    {
        // �ܺο� ����� ���� ������ ������ �ҷ��´�.
        gameData = dataHandler.DataLoad();  // dataHandler.DataLoad() �Լ��� ȣ���Ͽ� �����Ͱ� ������ �ش� �����͸� gameData �������� ��ȯ�ϰ�, ������ null�� ��ȯ�ϴ�.

        if (gameData == null)               // ���� �ܺο� ���� �����Ͱ� ���ٸ� ���ο� ������ ȣ���Ѵ�.
        {
            NewGame();
        }
        // ------------------------------------------------------------------------------------------
        // GameData Ŭ������ �ִ� �����͸� ���ӿ� �ʿ��� Ŭ������ ���� �����͸� �������ش�.
        foreach(var saveManager in saveManagers)
        {
            saveManager.LoadData(gameData);
        }
        
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<ISaveManager> FindAllSaveManagers()
    {
        IEnumerable<ISaveManager> saveManagers = FindObjectsOfType<MonoBehaviour>().OfType<ISaveManager>();

        return new List<ISaveManager>(saveManagers);
    }
}
