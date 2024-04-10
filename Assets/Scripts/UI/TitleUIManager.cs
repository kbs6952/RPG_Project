using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TitleUIManager : MonoBehaviour
{

    public void GameStart()
    {
        // ���� Application.persistantDataPath ��ο� �����͸� Listȭ �ؼ�. maxCount ������ ����� �մϴ�.

        // 00 ~ ������ ��ȣ Ž����. ��� �ִ� Slot�� ������, �ش� Slot ��ư�� �̸����� �����Ѵ�.

        LoadingUI.LoadScene("CameraSettingScene");
    }

    
    public void GameQuit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
}
