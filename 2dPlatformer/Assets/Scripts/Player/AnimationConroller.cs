using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationConroller : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private SpriteRenderer _reflector;
    [SerializeField] private Animator _animator;

    private int _speed = Animator.StringToHash(nameof(_speed));
    private int _isJump = Animator.StringToHash(nameof(_isJump));

    public void PlayRun(float axisDirection) 
    {
        if(axisDirection != 0)
            _reflector.flipX = axisDirection < 0;

        if (axisDirection < 0.01 || axisDirection > -0.01)
            _animator.SetFloat(_speed, Mathf.Abs(axisDirection) * movement.MoveSpeed);
        else
            _animator.SetFloat(_speed, 0);
    }

    public void PlayJump() 
    {
        _animator.SetBool(_isJump, true);
    }

    public void JumpAvalible() 
    {
        _animator.SetBool(_isJump, false);
    }
}