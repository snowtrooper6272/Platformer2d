using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMover : MonoBehaviour
{
    public void Move(float newPositionX)
    {
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
