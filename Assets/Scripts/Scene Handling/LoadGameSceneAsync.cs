using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameSceneAsync : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private TextMeshProUGUI _pleaseWait;
    [SerializeField] private TextMeshProUGUI _tipsAndTricks;
    [SerializeField] private SceneHandlerScriptableObject _sceneHandlerData;

    public void CallCoroutineToLoad()
    {
        StartCoroutine(LoadSceneAsyncCoroutine());
    }

    private IEnumerator LoadSceneAsyncCoroutine()
    {
        yield return null;
        SetupUpComponentContent();

        var operation = SceneManager.LoadSceneAsync(_sceneHandlerData.GetSceneName());
        operation.allowSceneActivation = false;
            
        while (!operation.isDone)
        {
            yield return null;
            if (!(operation.progress >= 0.9f)) continue;
            HasLoadedPressOption();
            if (!Input.GetKeyDown(KeyCode.Return)) continue;
            operation.allowSceneActivation = true;
        }
        yield return null;
    }

    private void SetupUpComponentContent()
    {
        _pleaseWait.text = _sceneHandlerData.GetPleaseWait(false);
        _tipsAndTricks.text = _sceneHandlerData.GetTips();
        _loadingScreen.SetActive(true);
    }

    private void HasLoadedPressOption()
    {
        _pleaseWait.text = _sceneHandlerData.GetPleaseWait(true);
    }
}