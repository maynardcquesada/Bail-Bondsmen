using System.Collections;
using UnityEngine;

public class HeadBobbing : MonoBehaviour
{
    [Header("Head Bobbing")] 
    [SerializeField] private bool _turnOnHeadBobbing;
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private float _defaultCamPosY;
    [SerializeField] private float _headBobbingRange;
    [SerializeField] private float _headBobSpeed;

    public void HeadBob()
    {
        if (!_turnOnHeadBobbing) return;
        var cameraTransform = _playerCamera.transform.localPosition;
        cameraTransform = new Vector3(cameraTransform.x, cameraTransform.y - _headBobbingRange, cameraTransform.z);
        StartCoroutine(PlayerHeadBobOnMove(cameraTransform));
    }

    private IEnumerator PlayerHeadBobOnMove(Vector3 targetPos)
    {
        float time = 0;
        var startPos = _playerCamera.transform.localPosition;
        while (time < _headBobSpeed / 2)
        {
            _playerCamera.transform.localPosition = Vector3.Lerp(startPos, targetPos, time / (_headBobSpeed / 2));
            time += Time.deltaTime;
            yield return null;
        }
        _playerCamera.transform.localPosition = targetPos;

        time = 0;
        startPos = targetPos;
        targetPos = new Vector3(startPos.x, _defaultCamPosY, startPos.z);
        while (time < _headBobSpeed / 2)
        {
            _playerCamera.transform.localPosition = Vector3.Lerp(startPos, targetPos, time / (_headBobSpeed / 2));
            time += Time.deltaTime;
            yield return null;
        }
        _playerCamera.transform.localPosition = targetPos;
    }
}
