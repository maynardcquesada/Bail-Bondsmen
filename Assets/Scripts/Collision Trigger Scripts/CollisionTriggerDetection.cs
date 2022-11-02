using RoboRyanTron.Unite2017.Events;
using UnityEngine;

public class CollisionTriggerDetection : MonoBehaviour
{
    [SerializeField] private GameEventWithScriptable _getSoulRaycastEvent;
    [SerializeField] private GameEventWithScriptable _whenPlayerSawDemonEvent;
    [SerializeField] private GameEventWithScriptable _getFrontAndBackWallRaycastEvent;
    private bool _isHit;
    private bool _sawDemonRaised;

    public void TurnOnWallSoulDemonRaycast()
    {
        _getFrontAndBackWallRaycastEvent.Raise();
        _getSoulRaycastEvent.Raise();
        _whenPlayerSawDemonEvent.Raise();
    }
}
