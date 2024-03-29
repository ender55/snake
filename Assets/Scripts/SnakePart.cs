﻿using System;
using UnityEngine;

public class SnakePart : MonoBehaviour, IMovable
{
    [SerializeField] private Vector3Int direction;

    private SnakeView snakeView;

    public SnakePart previousPart;
    public SnakePart nextPart;
    public Vector3Int Direction => direction;
    public IMovement Movement { get; set; } = new Movement();
    public SpriteRenderer SpriteRenderer { get; private set; }
    public SnakeViewData SnakeViewData { get; set; }

    private void Start()
    {
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        snakeView = new SnakeView(SnakeViewData);
    }

    private void FixedUpdate()
    {
        Movement.Move(transform, direction);
        SetDirectionUsingPreviousPart();
        if (nextPart == null)
        {
            snakeView.Draw(this);
        }
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
