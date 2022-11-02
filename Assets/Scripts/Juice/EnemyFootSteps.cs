using UnityEngine;

public class EnemyFootSteps : MonoBehaviour
{
    [SerializeField] private AudioSource _footStepsPlay;

    public void PlayDemonFootSteps()
    {
        if (!_footStepsPlay.isPlaying)
        {
            _footStepsPlay.Play();
        }
    }

    public void StopDemonFootSteps()
    {
        _footStepsPlay.Stop();
    }
}
