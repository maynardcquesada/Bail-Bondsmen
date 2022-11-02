using RoboRyanTron.Unite2017.Events;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private bool _isGameOver;
    [SerializeField] private GameEventWithScriptable _playFootSteps;
    [SerializeField] private GameEventWithScriptable _stopFootSteps;
    private readonly int _enemyMovingHash = Animator.StringToHash("isWalking");
    private const float stoppingVelocity = 0.12f;

    public void CheckGameOver()
    {
        _isGameOver = true;
    }
    
    public void AnimationControls(NavMeshAgent agent)
    {
        if (_isGameOver) return;
        _playFootSteps.Raise();
        _animator.SetBool(_enemyMovingHash, !(agent.velocity.magnitude < stoppingVelocity));
    }

    public void StopWalkingAnimation()
    {
        _stopFootSteps.Raise();
        _animator.SetBool(_enemyMovingHash, false);
    }
}