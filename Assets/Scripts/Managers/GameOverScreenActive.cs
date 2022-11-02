using System.Collections;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;

public class GameOverScreenActive : MonoBehaviour
{
    [SerializeField] private GameEventWithScriptable _gameOverMusic;
    [SerializeField] private AudioSource[] _audioSources;
    [SerializeField] private float _fadeTime = 5f;

    private void Start()
    {
        _gameOverMusic.Raise();
        foreach (var VARIABLE in _audioSources)
        {
            StartCoroutine(FadeOutVolume(VARIABLE));
        }
    }

    private IEnumerator FadeOutVolume(AudioSource audioSource)
    {
        var startVolume = audioSource.volume;
 
        while (audioSource.volume > 0) {
            audioSource.volume -= startVolume * Time.deltaTime / _fadeTime;
 
            yield return null;
        }
 
        audioSource.Stop ();
    }
}