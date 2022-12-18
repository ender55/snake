using System;
using UnityEngine;

public class Snake : MonoBehaviour, IMovementControllable
{
    public SnakePart Head;
    public SnakePart Tail;
    public IMovementInputController MovementInputController { get; set; } = new SnakeKeyboardMovementInputController();

    public void Update()
    {
        Head.SetDirection(MovementInputController.HandleInput());
    }
}