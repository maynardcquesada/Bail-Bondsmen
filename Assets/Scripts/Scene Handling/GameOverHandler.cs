using RoboRyanTron.Unite2017.Events;
using TMPro;
using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _totalScore;
    [SerializeField] private TextMeshProUGUI _highScore;
    [SerializeField] private ScoreToSoul _scoreToSoul;
    [SerializeField] private GameEventWithScriptable _isGameOver;

    public void GameOver()
    {
        _isGameOver.Raise();
        _scoreToSoul.GameObjectQueue.Clear();
        SetScoreComponentsToDisplay();
        ResetScoreOnScriptable();
    }

    private void SetScoreComponentsToDisplay()
    {
        _totalScore.text = _scoreToSoul.SoulCollected.ToString();
        _highScore.text = _scoreToSoul.GetMaxSoulCollected().ToString();
    }

    private void ResetScoreOnScriptable()
    {
        _scoreToSoul.ReturnSoulCollectedZero();
    }

}
