using RoboRyanTron.Unite2017.Events;
using UnityEngine;

public class DistanceBetweenPlayerAndDemon : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _demonTransform;
    [SerializeField] private float _distanceToActivateFx;
    [SerializeField] private GameEventWithScriptable _distanceToGlitch;

    private void Update()
    {
        var distance = Vector3.Distance(_playerTransform.transform.position, _demonTransform.transform.position);
        if (!(distance <= _distanceToActivateFx)) return;
        if (distance < 2)
        {
            distance = 2;
        }
        
        _distanceToGlitch.Raise(2 / distance, (2 / distance) - 0.2f);
    }
}
