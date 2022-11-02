using UnityEngine;

[CreateAssetMenu(fileName = "Difficulty Data", menuName = "ScriptableObjects/Difficulty Level Data", order = 8)]
public class DifficultyLevelData : ScriptableObject
{
    [SerializeField] private int _dificultyLevel;

    public int DificultyLevel
    {
        get => _dificultyLevel;
        set => _dificultyLevel = value;
    }
}