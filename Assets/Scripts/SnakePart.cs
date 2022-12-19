using System;
using System.Collections;
using UnityEngine;

public class SnakePart : MonoBehaviour, IMovable
{
    [SerializeField] private Vector3Int direction;

    private SnakeView snakeView;
    private SnakePart snakePart;
    
    public IMovement Movement { get; set; } = new Movement();
    
    public SnakePart previousPart;
    public SnakePart nextPart;
    public Vector3Int Direction => direction;
    public SpriteRenderer SpriteRenderer { get; private set; }
    public SnakeViewData SnakeViewData { get; set; }
    
    private void Start()
    {
        snakePart = gameObject.GetComponent<SnakePart>();
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        snakeView = new SnakeView(SnakeViewData);
        snakeView.Draw(snakePart);
    }

    public void UpdateMovement()
    {
        Movement.Move(transform, direction);
    }

    public void UpdateView()
    {
        snakeView.Draw(snakePart);
    }

    public void SetDirectionUsingPreviousPart()
    {
        if (previousPart != null)
        {
            var temp = Vector3Int.RoundToInt(previousPart.transform.position - transform.position);
            SetDirection(temp);
        }
    }
    
    public void SetDirection(Vector3Int value)
    {
        direction = value;
    }
}
