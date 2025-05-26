using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    private float _leftLookRotation = 180;
    private float _rightLookRotation = 0;

    public void Flip(float flipDirection) 
    {
        if (flipDirection == 1)
        {
            transform.rotation = Quaternion.Euler(0, _rightLookRotation, 0);
        }
        else 
        {
            transform.rotation = Quaternion.Euler(0, _leftLookRotation, 0);
        }
    }
}
