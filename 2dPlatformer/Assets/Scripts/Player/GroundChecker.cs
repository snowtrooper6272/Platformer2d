using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _animator;

    public event Action Grounded;
    public bool IsPossibleJump { get; private set; } = true;

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsPossibleJump = false;

        foreach (ContactPoint2D contactPoint in collision.contacts)
        {
            if (contactPoint.collider.gameObject.TryGetComponent(out Ground ground))
            {
                IsPossibleJump = true;
                Grounded.Invoke();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsPossibleJump = false;

        foreach (ContactPoint2D contactPoint in collision.contacts)
        {
            if (contactPoint.collider.gameObject.TryGetComponent(out Ground ground))
            {
                IsPossibleJump = true;
                Grounded.Invoke();
            }
        }
    }
}
