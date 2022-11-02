using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score To Soul", menuName = "ScriptableObjects/Score To Soul", order = 7)]
public class ScoreToSoul : ScriptableObject
{
    [SerializeField] private int _soulCollected;
    [SerializeField] private int _maxSoulCollected;

    public int SoulCollected
    {
        get => _soulCollected;
        set => _soulCollected = value;
    }

    public Queue<GameObject> GameObjectQueue { get; } = new();

    public void ReturnSoulCollectedZero()
    {
        _soulCollected = 0;
    }

    public int GetMaxSoulCollected()
    {
        if (_soulCollected > _maxSoulCollected)
        {
            _maxSoulCollected = _soulCollected;
        }
        return _maxSoulCollected;
    }
}