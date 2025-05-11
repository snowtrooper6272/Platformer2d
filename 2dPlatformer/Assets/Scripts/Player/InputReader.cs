using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private string _moveAxis = "Horizontal";
    private KeyCode _jumpButton = KeyCode.Space;

    public float AxisDirection { get; private set; }

    public event Action<float> PlayerMoved;
    public event Action PlayerJumped;
    public event Action<float> PlayerInactived;

    private void Update()
    {
        AxisDirection = Input.GetAxis(_moveAxis);

        if (Input.GetKeyDown(_jumpButton))
        {
            PlayerJumped.Invoke();
        }
    }
}
