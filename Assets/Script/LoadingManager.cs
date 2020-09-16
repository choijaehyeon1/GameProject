using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public static string nextScene;
    public static string nextPlayerStart;

    [SerializeField]
    Image progressBar;

    private void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    public static void LoadScene(string sceneName, string playerStart = null)
    {
        nextScene = sceneName;
        nextPlayerStart = playerStart;
        SceneManager.LoadScene("Loading");        

    }

    IEnumerator LoadSceneAsync()
    {
        yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        op.completed += SpawnPlayer;

        float timer = 0.0f;

        while (!op.isDone)
        {
            yield return null;

            timer += Time.deltaTime;

            if(op.progress < 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);

                yield return null;

                op.allowSceneActivation = true;                    
            }
        }
    }

    private void SpawnPlayer(AsyncOperation obj)
    {
        GameManager.Instance.SpawnPlayer(nextPlayerStart);
    }
}
