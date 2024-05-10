using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingUIManager : MonoBehaviour
{
    static string nextSceneName;                    // ���� Scene���� �Ѿ Scene �̸��� string�� �����ϴ� ����

    [SerializeField] private Image progressBar;

    private void Start()
    {
        // �ε� Process�� �����ؼ� �ش� Process�� �Ϸ�Ǹ� ���� Scene���� �Ѿ��
        StartCoroutine(LoadSceneProcess());
    }
    public static void LoadScene(string SceneName)
    {
        nextSceneName = SceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadSceneProcess()                  // �� ���� �ּ����� ���ð��� �����ִ� ���μ���
    {
        yield return new WaitForSeconds(0.3f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(nextSceneName);
        operation.allowSceneActivation = false;         // ���� ������ �ڵ����� ���������� �Ѿ���ΰ�? true�� �Ѿ

        float timer = 0f;

        while (!operation.isDone)
        {
            yield return null;          // �����Ӹ��� �Ʒ� ������ �ݿ�

            if (operation.progress < 0.9f)
            {
                progressBar.fillAmount = operation.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;                            // Unity���� �������ִ� �ð��� �ƴ� �������� �ð����� �Ѱ���
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if (progressBar.fillAmount >= 1f)
                {
                    yield return new WaitForSeconds(1f);
                    operation.allowSceneActivation = true;
                }
                yield return null;
            }
        }
    }
}
