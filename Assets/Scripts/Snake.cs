using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Snake : MonoBehaviour, IMovementControllable, IMovable
{
    private SnakeView snakeView;

    public SnakeViewData SnakeViewData;
    public SnakePart Head;
    public SnakePart Tail;
    public IMovementInputController MovementInputController { get; set; } = new SnakeKeyboardMovementInputController();
    public IMovement Movement { get; set; } = new Movement();
    public event Action<SnakePart, Snake> OnGrowth;
    public static event Action OnDeath;

    private void Start()
    {
        var rigidbody = gameObject.AddComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0f;
        var boxCollider = gameObject.AddComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(0.8f, 0.8f);
        boxCollider.isTrigger = true;
        snakeView = new SnakeView(SnakeViewData);
    }

    public void Update()
    {
        Head.SetDirection(MovementInputController.HandleInput());
    }

    private void FixedUpdate()
    {
        UpdateSnake();
    }

    private void UpdateSnake()
    {
        Movement.Move(transform, Head.Direction);
        bool isTail = false;
        var snakePart = Tail;
        while (!isTail)
        {
            snakePart.UpdateMovement();
            if (snakePart.previousPart == null)
            {
                isTail = true;
            }

            snakePart = snakePart.previousPart;
        }
        isTail = false;
        snakePart = Head;
        while (!isTail)
        {
            snakePart.SetDirectionUsingPreviousPart();
            if (snakePart.nextPart == null)
            {
                isTail = true;
                
            }

            snakePart = snakePart.nextPart;
        }
        isTail = false;
        snakePart = Head;
        while (!isTail)
        {
            snakePart.UpdateView();
            if (snakePart.nextPart == null)
            {
                isTail = true;
            }

            snakePart = snakePart.nextPart;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Food food))
        {
            OnGrowth?.Invoke(Tail, this);
        }
        else
        {
            OnDeath?.Invoke();
        }
    }
}