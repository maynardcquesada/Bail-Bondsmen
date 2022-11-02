using UnityEngine;

[CreateAssetMenu(fileName = "Raycast Value", menuName = "ScriptableObjects/Raycast Value", order = 3)]
public class RaycastValueScriptable : ScriptableObject
{
    [SerializeField] private float _raycastRange;
    [SerializeField] private float _raycastForDemon;

    public float GetRaycastRange()
    {
        return _raycastRange;
    }

    public float GetRaycastForDemon()
    {
        return  _raycastForDemon;
    }
}
