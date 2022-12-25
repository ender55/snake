using System;
using UnityEngine;

public class Snake : MonoBehaviour, IMovementControllable, IMovable
{
    private SnakePart head;
    private SnakePart tail;
    private SnakeView snakeView;

    public SnakeViewData SnakeViewData;
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

    private void Update()
    {
        head.SetDirection(MovementInputController.HandleInput());
    }

    private void FixedUpdate()
    {
        UpdateSnake();
    }

    private void UpdateSnake()
    {
        //todo: убрать это из снейк и сделать подписку на ивент в хвосте змеи
        Movement.Move(transform, head.Direction);
        bool isTail = false;
        var snakePart = tail;
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
        snakePart = head;
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
        snakePart = head;
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
            OnGrowth?.Invoke(tail, this);
        }
        else
        {
            OnDeath?.Invoke();
        }
    }

    public void Add(SnakePart snakePart)
    {
        if (head == null)
        {
            head = snakePart;
        }
        else
        {
            tail.nextPart = snakePart;
            snakePart.previousPart = tail;
        }

        tail = snakePart;
    }
}