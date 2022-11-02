using UnityEngine;

[CreateAssetMenu(fileName = "Scene Handler", menuName = "ScriptableObjects/Scene Handler", order = 1)]
public class SceneHandlerScriptableObject : ScriptableObject
{
    [SerializeField] private string[] _tips;
    [SerializeField] private Object _gameScene;
    [SerializeField] private string _pleaseWait;
    [SerializeField] private string _pressEnter;
    
    public string GetTips()
    {
        return _tips[Random.Range(0, _tips.Length)];
    }

    public string GetSceneName()
    {
        return _gameScene.name;
    }

    public string GetPleaseWait(bool isDoneChangeToInput)
    {
        return isDoneChangeToInput ? _pressEnter : _pleaseWait;
    }
}
