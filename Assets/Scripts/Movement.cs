using System;
using UnityEngine;

class Movement : IMovement
{
    public void Move(Transform transform, Vector3 direction)
    {
        transform.position += direction;
    }
}