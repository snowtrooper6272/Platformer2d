using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private string _moveAxis = "Horizontal";
    public float AxisDirection { get; private set; }

    private void Update()
    {
        AxisDirection = Input.GetAxis(_moveAxis);
    }
}
