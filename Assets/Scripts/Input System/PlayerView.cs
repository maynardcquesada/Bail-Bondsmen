using RoboRyanTron.Unite2017.Events;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Image _openEyes;
    [SerializeField] private GameEventWithScriptable _closeEyes;

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        _closeEyes.Raise();
        _openEyes.enabled = !_openEyes.IsActive();
    }
}