using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Movement Values", menuName = "ScriptableObjects/Character Movement Values", order = 2)]
public class CharacterMovementValues : ScriptableObject
{
    [SerializeField] private float _rotationSpeed = 3f;
    [SerializeField] private float _movementSpeed = 0.2f;

    public float GetRotationSpeed()
    {
        return _rotationSpeed;
    }
    
    public float GetMovementSpeed()
    {
        return _movementSpeed;
    }
}
