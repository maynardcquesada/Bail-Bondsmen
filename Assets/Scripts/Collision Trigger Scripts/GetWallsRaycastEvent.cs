using RoboRyanTron.Unite2017.Events;
using UnityEngine;

public class GetWallsRaycastEvent : MonoBehaviour
{
    [SerializeField] private GameEventWithScriptable _wallOnFrontAndBackEvent;
    [SerializeField] private RaycastValueScriptable _raycastValue;
    [SerializeField] private LayerMask _wallsLayer;
    [SerializeField] private GameEventWithScriptable _checkIfFrontIsBlockedEvent;
    
    #region Get Wall Raycast Values
    
    public void GetFrontAndBackWallRaycast()
    {
        _wallOnFrontAndBackEvent.Raise(GetFrontRaycast(), GetBackRaycast());
    }

    private bool GetFrontRaycast()
    {
        var tempGetFrontRaycast = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),
            _raycastValue.GetRaycastRange(), _wallsLayer);
        _checkIfFrontIsBlockedEvent.Raise(tempGetFrontRaycast);
        return tempGetFrontRaycast;
    }

    private bool GetBackRaycast()
    {
        return Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), 
            _raycastValue.GetRaycastRange(), _wallsLayer);
    }

    #endregion
}
