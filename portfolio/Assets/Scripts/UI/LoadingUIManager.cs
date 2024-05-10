using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingUIManager : MonoBehaviour
{
    static string nextSceneName;                    // 다음 Scene으로 넘어갈 Scene 이름의 string을 저장하는 변수

    [SerializeField] private Image progressBar;

    private void Start()
    {
        // 로딩 Process를 진행해서 해당 Process가 완료되면 다음 Scene으로 넘어간다
        StartCoroutine(LoadSceneProcess());
    }
    public static void LoadScene(string SceneName)
    {
        nextSceneName = SceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadSceneProcess()                  // 씬 간의 최소한의 대기시간을 벌어주는 프로세스
    {
        yield return new WaitForSeconds(0.3f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(nextSceneName);
        operation.allowSceneActivation = false;         // 씬이 끝날때 자동으로 다음씬으로 넘어갈것인가? true면 넘어감

        float timer = 0f;

        while (!operation.isDone)
        {
            yield return null;          // 프레임마다 아래 내용을 반영

            if (operation.progress < 0.9f)
            {
                progressBar.fillAmount = operation.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;                            // Unity에서 제공해주는 시간이 아닌 고정적인 시간값을 넘겨줌
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
