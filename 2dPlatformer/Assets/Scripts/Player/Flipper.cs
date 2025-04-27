using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    private float _degreesRotation = 90;

    public void Flip(float flipDirection) 
    {
        transform.rotation = Quaternion.Euler(0,90 - _degreesRotation * flipDirection,0);
    }
}
