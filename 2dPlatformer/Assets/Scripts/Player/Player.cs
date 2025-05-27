using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Mover _mover;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private GroundChecker _groundChecker;

    private void OnEnable()
    {
        _groundChecker.Grounded += SetGrounded;
    }

    private void OnDisable()
    {
        _groundChecker.Grounded -= SetGrounded;
    }

    private void Update()
    {
        _animator.PlayRun(_inputReader.AxisDirection, _mover.MoveSpeed);

        if (_inputReader.AxisDirection > 0)
            _flipper.Flip(1);
        else if (_inputReader.AxisDirection < 0)
            _flipper.Flip(-1);
    }

    private void FixedUpdate()
    {
        _mover.Move(_inputReader.AxisDirection);

        if (_jumper.IsJumpKeyDown)
        {
            _jumper.Jump();
            _animator.PlayJump();
        }
    }

    private void SetGrounded()
    {
        _animator.Aterrissagem();
        _jumper.SetGrounded();
    }
}
