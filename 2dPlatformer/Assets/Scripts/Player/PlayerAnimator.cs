using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Animator _animator;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private GroundChecker _groundChecker;

    private readonly int _speed = Animator.StringToHash(nameof(_speed));
    private readonly int _isJump = Animator.StringToHash(nameof(_isJump));

    private void OnEnable()
    {
        _groundChecker.Grounded += Aterrissagem;
    }

    private void OnDisable()
    {
        _groundChecker.Grounded -= Aterrissagem;
    }

    public void PlayRun(float axisDirection) 
    {
        if (axisDirection != 0)
        {
            if (axisDirection > 0)
                _flipper.Flip(1);
            else
                _flipper.Flip(-1);
        }


        if (axisDirection < 0 || axisDirection > 0)
            _animator.SetFloat(_speed, Mathf.Abs(axisDirection) * _mover.MoveSpeed);
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