using System;
using UnityEngine;

public class Snake : MonoBehaviour, IMovementControllable, IMovable
{
    private SnakePart head;
    private SnakePart tail;

    public SnakeViewData SnakeViewData;
    public IMovementInputController MovementInputController { get; set; } = new SnakeKeyboardMovementInputController();
    public IMovement Movement { get; set; } = new Movement();
    public event Action<Snake, SnakePart> OnGrowth;
    public static event Action OnDeath;

    private void Start()
    {
        var rigidbody = gameObject.AddComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0f;
        var boxCollider = gameObject.AddComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(0.8f, 0.8f);
        boxCollider.isTrigger = true;
    }

    private void Update()
    {
        head.SetDirection(MovementInputController.HandleInput());
    }

    private void FixedUpdate()
    {
        Movement.Move(transform, head.Direction);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Food food))
        {
            OnGrowth?.Invoke(this, tail);
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