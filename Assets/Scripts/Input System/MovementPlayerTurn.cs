using System.Collections;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;

namespace Input_System
{
    public class MovementPlayerTurn : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private CharacterMovementValues _characterMovementValues;
        [SerializeField] private GameEventWithScriptable _isTurning;
    
        private float _previousYAngle = -180f;
        private float _currentYAngle;
    
        private const string _horizontal = "Horizontal";
        private const float _angleToAdd = 90;

        public void PlayerTurn()
        {
            _currentYAngle = _previousYAngle + (Input.GetAxisRaw(_horizontal) * _angleToAdd);
            StartCoroutine(Rotate(_currentYAngle));
            _previousYAngle = _currentYAngle;
        }
    
        private IEnumerator Rotate(float targetAngle)
        {
            float time = 0;
            while (time < _characterMovementValues.GetRotationSpeed())
            {
                _isTurning.Raise(true);
                _playerTransform.transform.rotation = Quaternion.Slerp(_playerTransform.transform.rotation, Quaternion.Euler(0f, targetAngle, 0f), time / _characterMovementValues.GetRotationSpeed());
                time += Time.deltaTime;
                if (_playerTransform.transform.rotation == Quaternion.Euler(0f, targetAngle, 0f))
                {
                    _isTurning.Raise(false);
                }
                yield return null;
            }
            _playerTransform.transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
        }
    }
}
