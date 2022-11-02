using System.Collections;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] private GameEventWithScriptable _enemyToPlayerAskForPos;
    [SerializeField] private GameEventWithScriptable _animationControlsWalk;
    [SerializeField] private Vector3 _playerPosForEnemy;
    [SerializeField] private NavMeshAgent _demon;

    private void Update()
    {
        if (!_demon.hasPath)
        {
            RandomSetDestination();
            if(_demon.pathStatus == NavMeshPathStatus.PathComplete)
            {
                _enemyToPlayerAskForPos.Raise();
                StartCoroutine(DelayNextPosition());
            }
        }
        _animationControlsWalk.Raise(_demon);
    }

    private IEnumerator DelayNextPosition()
    {
        _demon.isStopped = true;
        if (_demon.isStopped)
        {
            yield return new WaitForSeconds(5);
        }
        _demon.isStopped = false;
    }

    private void RandomSetDestination()
    {
        _demon.SetDestination(_playerPosForEnemy);
    }

    public void SetPlayerPosForEnemy(Vector3 playerPos)
    {
        _playerPosForEnemy = playerPos;
    }
}