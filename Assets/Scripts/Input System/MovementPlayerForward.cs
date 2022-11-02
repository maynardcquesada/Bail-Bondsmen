using System.Collections;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;

namespace Input_System
{
    public class MovementPlayerForward : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private CharacterMovementValues _characterMovementValues;
        [SerializeField] private GameEventWithScriptable _isPlayerWalking;
        [SerializeField] private GameEventWithScriptable _isMoving;
        private const string _vertical = "Vertical";
    
        public void PlayerMove()
        {
            _isPlayerWalking.Raise();
            StartCoroutine(Move(_playerTransform.position + (_playerTransform.forward * Input.GetAxisRaw(_vertical))));
        }
    
        private IEnumerator Move(Vector3 targetPos)
        {
            float time = 0;
            var startPos = _playerTransform.position;
            while (time < _characterMovementValues.GetMovementSpeed())
            {
                _isMoving.Raise(true);
                _playerTransform.position = Vector3.Lerp(startPos, targetPos, time / _characterMovementValues.GetMovementSpeed());
                time += Time.deltaTime;
                yield return null;
            }
            _playerTransform.position = targetPos;
            _isMoving.Raise(false);
        }
    }
}