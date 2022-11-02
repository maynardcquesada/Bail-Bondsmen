using RoboRyanTron.Unite2017.Events;
using UnityEngine;
using Random = UnityEngine.Random;

public class SendLocationForEnemy : MonoBehaviour
{
    [SerializeField] private GameEventWithScriptable _playerToEnemySendPos;
    [SerializeField] private DifficultyLevelData _difficultyLevel;
    
    private void Awake()
    {
        SendEnemyMyRandomLocation();
    }

    public void SendEnemyMyRandomLocation()
    {
        var position = transform.position;
        _playerToEnemySendPos.Raise(_difficultyLevel.DificultyLevel > 0 ? GenerateRandomLocation() : position);
    }

    private Vector3 GenerateRandomLocation()
    {
        return new Vector3(Random.insideUnitSphere.x * _difficultyLevel.DificultyLevel, transform.position.y,
            Random.insideUnitSphere.z * _difficultyLevel.DificultyLevel);
    }
}
