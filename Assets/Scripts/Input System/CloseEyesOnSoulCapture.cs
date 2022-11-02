using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CloseEyesOnSoulCapture : MonoBehaviour
{
    [SerializeField] private Image _closeEyesCapture;

    public void CloseEyesOnCaptureRoutine()
    {
        StartCoroutine(CloseEyesOnCapture());
    }

    private IEnumerator CloseEyesOnCapture()
    {
        _closeEyesCapture.enabled = true;
        yield return new WaitForSeconds(0.5f);
        _closeEyesCapture.enabled = false;
    }
}
