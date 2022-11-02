using RoboRyanTron.Unite2017.Events;
using UnityEngine;

public class ScoreChecker : MonoBehaviour
{
    [SerializeField] private ScoreToSoul _scoreToSoul;
    [SerializeField] private DifficultyLevelData _difficultyLevel;
    [SerializeField] private GameEventWithScriptable _changeDifficulty;
    private bool difficultyIsChanged;

    private void Awake()
    {
        _scoreToSoul.ReturnSoulCollectedZero();
    }

    public void Update()
    {
        if (!CheckIfAllSoulsAreCaptured()) return;
        if(ShouldDifficultyBeChanged())
        {
            _changeDifficulty.Raise();
        }
        AllSoulsCaptured();
        difficultyIsChanged = true;
    }

    private bool CheckIfAllSoulsAreCaptured()
    {
        return _scoreToSoul.SoulCollected % 5 == 0 && _scoreToSoul.SoulCollected != 0;
    }

    private bool ShouldDifficultyBeChanged()
    {
        return _scoreToSoul.GameObjectQueue.Count == 5 && !difficultyIsChanged && _difficultyLevel.DificultyLevel > 0;
    }

    private void AllSoulsCaptured()
    {
        difficultyIsChanged = false;
        for (var i = 0; i < _scoreToSoul.GameObjectQueue.Count - 1; i++)
        {
            _scoreToSoul.GameObjectQueue.Dequeue().SetActive(true);
        }
    }

}
