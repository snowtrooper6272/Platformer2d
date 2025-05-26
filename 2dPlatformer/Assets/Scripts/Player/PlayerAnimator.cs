using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Flipper _flipper;

    private readonly int _speed = Animator.StringToHash(nameof(_speed));
    private readonly int _isJump = Animator.StringToHash(nameof(_isJump));

    public void PlayRun(float axisDirection, float speed) 
    {
        if (axisDirection != 0)
        {
            if (axisDirection > 0)
                _flipper.Flip(1);
            else
                _flipper.Flip(-1);
        }

        if (axisDirection < 0 || axisDirection > 0)
            _animator.SetFloat(_speed, Mathf.Abs(axisDirection) * speed);
        else
            _animator.SetFloat(_speed, 0);
    }

    public void PlayJump() 
    {
        _animator.SetBool(_isJump, true);
    }

    public void Aterrissagem() 
    {
        _animator.SetBool(_isJump, false);
    }
}