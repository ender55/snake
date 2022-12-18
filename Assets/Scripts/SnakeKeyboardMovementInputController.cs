using System;
using UnityEngine;

[Serializable]
class SnakeKeyboardMovementInputController : IMovementInputController
{
    public PlayerKeyCodes PlayerKeyCodes { get; set; }
    public Vector3Int Direction { get; set; }
    
    public Vector3Int HandleInput()
    {
        if (Direction.x != 0)
        {
            if (Input.GetKeyDown(PlayerKeyCodes.up))
            {
                Direction = new Vector3Int(0, 1, 0);
            }
            else if (Input.GetKeyDown(PlayerKeyCodes.down))
            {
                Direction = new Vector3Int(0, -1, 0);
            }
        }
        else if (Direction.y != 0)
        {
            if (Input.GetKeyDown(PlayerKeyCodes.left))
            {
                Direction = new Vector3Int(-1, 0, 0);
            }
            else if (Input.GetKeyDown(PlayerKeyCodes.right))
            {
                Direction = new Vector3Int(1, 0, 0);
            }
        }

        return Direction;
    }
}