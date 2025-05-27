using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public float AxisDirection { get; private set; }

    private string _moveAxis = "Horizontal";

    private void Update()
    {
        AxisDirection = Input.GetAxis(_moveAxis);
    }
}
