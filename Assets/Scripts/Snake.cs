using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Snake : MonoBehaviour, IMovementControllable, IMovable
{
    public SnakePart Head;
    public SnakePart Tail;
    public IMovementInputController MovementInputController { get; set; } = new SnakeKeyboardMovementInputController();
    public IMovement Movement { get; set; } = new Movement();

    public void Update()
    {
        Head.SetDirection(MovementInputController.HandleInput());
    }

    private void FixedUpdate()
    {
        Movement.Move(transform, Head.Direction);
    }
}