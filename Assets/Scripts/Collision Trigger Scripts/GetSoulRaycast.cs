using System.Collections;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;

public class GetSoulRaycast : MonoBehaviour
{
    [SerializeField] private GameEventWithScriptable _soulDetected;
    [SerializeField] private RaycastValueScriptable _raycastValue;
    [SerializeField] private LayerMask _soulsLayer;
    private bool _isHit;
    
    #region Soul Raycast Methods

    public void GetSoulRaycastEvent()
    {
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),
                out var hit, _raycastValue.GetRaycastRange(), _soulsLayer) || _isHit) return;
        ActOnSoulHit(hit);
    }

    private void ActOnSoulHit(RaycastHit hit)
    {
        _soulDetected.Raise(hit.collider.name);
        _isHit = true;
        StartCoroutine(IsHitToFalseDelay());
    }

    private IEnumerator IsHitToFalseDelay()
    {
        yield return new WaitForSeconds(1);
        _isHit = false;
    }

    #endregion
}
