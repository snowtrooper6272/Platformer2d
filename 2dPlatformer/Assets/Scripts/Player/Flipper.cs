using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private PlayerAnimator _animator;

    private float _degreesRotation = 90;

    private void OnEnable()
    {
        _animator.Flipped += Flip;
    }

    private void OnDisable()
    {
        _animator.Flipped -= Flip;
    }

    public void Flip(float flipDirection) 
    {
        transform.rotation = Quaternion.Euler(0,90 - _degreesRotation * flipDirection,0);
    }
}
