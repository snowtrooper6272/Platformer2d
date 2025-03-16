using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private AnimationConroller _animationConroller;

    public bool IsPossibleJump { get; private set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            IsPossibleJump = true;
            _animationConroller.JumpAvalible();
        }
    }
}
