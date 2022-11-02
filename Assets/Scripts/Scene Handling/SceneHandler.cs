using RoboRyanTron.Unite2017.Events;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private GameEventWithScriptable _loadSceneOnEnter;
    [SerializeField] private GameEventWithScriptable _disableGameOverScreenOnReturn;
    private bool _pressOnce;
    
    // Update is called once per frame
    private void Update()
    {
        MainMenuInputHandler();
    }

    private void MainMenuInputHandler()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !_pressOnce)
        {
            RaiseEventsOnEnter();
            _pressOnce = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void RaiseEventsOnEnter()
    {
        _disableGameOverScreenOnReturn.Raise();
        _loadSceneOnEnter.Raise();
    }
}