using UnityEngine;

public class FootStepScript : MonoBehaviour
{
    [SerializeField] private AudioSource _footStep;

    public void PlayFootSteps()
    {
        if (!_footStep.isPlaying)
        {
            _footStep.Play();
        }
    }
}
