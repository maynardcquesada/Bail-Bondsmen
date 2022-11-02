using RoboRyanTron.Unite2017.Events;
using UnityEngine;

public class WhenPlayerSawDemonEvent : MonoBehaviour
{
    [SerializeField] private GameEventWithScriptable _playerSeesDemon;
    private bool _sawDemonRaised;
    [SerializeField] private bool _checkFrontRaycast;
    [SerializeField] private RaycastValueScriptable _raycastValue;
    [SerializeField] private LayerMask _demonLayer;
    
    #region Player Saw Demon Raycast

    public void WhenPlayerSawDemon()
    {
        if (!PlayerSawDemon()) return;
        _playerSeesDemon.Raise();
        _sawDemonRaised = true;
    }
    
    private bool PlayerSawDemon()
    {
        if (_checkFrontRaycast) return false;
        if (!_sawDemonRaised)
        {
            return Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),
                _raycastValue.GetRaycastForDemon(), _demonLayer);
        }
        return false;
    }

    public void CheckFrontRaycastIfBlocked(bool checkFrontRaycastBlocked)
    {
        _checkFrontRaycast = checkFrontRaycastBlocked;
    }

    #endregion
}
