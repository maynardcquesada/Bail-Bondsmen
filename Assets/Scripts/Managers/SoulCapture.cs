using System.Collections;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;

public class SoulCapture : MonoBehaviour
{
    [SerializeField] private ScoreToSoul _scoreToSoul;
    [SerializeField] private GameEventWithScriptable _closeEyesOnCapture;

    public void DecisionOnSouls(string thisGameObjectName)
    {
        if (CheckIfLocalGameObjectSameWithRaycast(thisGameObjectName)) return;
        AddScore();
        EnableSoulAgainFIFO();
        StoreGameObject();
        StartCoroutine(SoulIsCaptured());
    }

    private bool CheckIfLocalGameObjectSameWithRaycast(string thisGameObjectName)
    {
        return thisGameObjectName != gameObject.name;
    }

    private void AddScore()
    {
        _scoreToSoul.SoulCollected++;
    }

    private void StoreGameObject()
    {
        _scoreToSoul.GameObjectQueue.Enqueue(gameObject);
    }

    private void EnableSoulAgainFIFO()
    {
        if (_scoreToSoul.SoulCollected % 5 == 1 && _scoreToSoul.GameObjectQueue.Count == 1)
        {
            _scoreToSoul.GameObjectQueue.Dequeue().SetActive(true);
        }
    }

    private IEnumerator SoulIsCaptured()
    {
        _closeEyesOnCapture.Raise();
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
