using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{
    static string nextScene; // ���� ������ �Ѿ� �� Scene �̸��� ���� �����ϴ� ����

    [SerializeField] private Image progrssBar;

    private void Start()
    {
        // �ε� Process �����ؼ� �ش� ���μ��� �Ϸ�Ǹ� ���� ������ �̵��Ѵ�.

        StartCoroutine(LoadSceneProcess());
    }

    public static void LoadScene(string SceneName)
    {
        nextScene = SceneName;

        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadSceneProcess()
    {
        yield return new WaitForSeconds(0.3f); // ���� :

        AsyncOperation operation = SceneManager.LoadSceneAsync(nextScene);
        operation.allowSceneActivation = false; // ���� ���� �� �ڵ����� ���� ������ �̵��� ���ΰ�? true : �ڵ����� �̵�, false : �̵��� ����
                                                // �ε� �߿� �ּ����� ��� �ð��� �ο��մϴ�.
        float timer = 0f;

        while (!operation.isDone)
        {
            yield return null;   // �����Ӹ��� �Ʒ� ������ �ݿ�

            if(operation.progress < 0.9f)                          
            {
                progrssBar.fillAmount = operation.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;                             // Time.Scale �����ų ���� �ֽ��ϴ�. - 
                progrssBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);         // 90% -> 100% ������ �̹��� ���� ������������ ǥ�� ( 90 -> 100,, õõ�� 90- > 100 ���� ǥ��)
                if(progrssBar.fillAmount >= 1f)
                {
                    yield return new WaitForSeconds(1f);
                    operation.allowSceneActivation = true;
                }

                yield return null;
            }
        }
        
   }
}
