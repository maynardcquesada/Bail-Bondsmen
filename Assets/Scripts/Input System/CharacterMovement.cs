using RoboRyanTron.Unite2017.Events;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private GameEventWithScriptable _turnOnWallSoulRaycast;
    [SerializeField] private GameEventWithScriptable _playerTurn;
    [SerializeField] private GameEventWithScriptable _playerMove;
    
    private const string _vertical = "Vertical";

    private bool _isTurning;
    private bool _isMoving;
    private bool _eyesClose;

    private bool _wallOnFront;
    private bool _wallOnBack;

    private void Update()
    {
        MovementControls();
    }
    
    private void MovementControls()
    {
        if (_eyesClose) return;
        if (!PlayerMoveInputPossible()) return;
        if (PlayerCanTurn())
        {
            _playerTurn.Raise();
        }
        _turnOnWallSoulRaycast.Raise();
        if (!PlayerCanMove()) return;
        _playerMove.Raise();
    }

    #region Movement Validations

    private bool PlayerMoveInputPossible()
    {
        return !_isMoving && !_isTurning;
    }

    public void SetWallOnFrontAndBack(bool frontWall, bool backWall)
    {
        _wallOnFront = frontWall;
        _wallOnBack = backWall;
    }

    #endregion

    #region Movement Inputs

    private static bool PlayerCanTurn()
    {
        return Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow);
    }
    
    private bool PlayerCanMove()
    {
        if (Input.GetAxisRaw(_vertical) > 0 && !_wallOnFront)
        {
            return true;
        }
        return Input.GetAxisRaw(_vertical) < 0 && !_wallOnBack;
    }

    #endregion

    #region Events Affecting Movement

    public void IsTurning(bool isTurning)
    {
        _isTurning = isTurning;
    }
    
    public void IsMoving(bool isMoving)
    {
        _isMoving = isMoving;
    }
    
    public void PlayerEyesClose()
    {
        _eyesClose = !_eyesClose;
    }

    #endregion
    
}