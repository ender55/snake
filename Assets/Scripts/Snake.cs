using System;
using System.Collections.Generic;
using UnityEngine;

public class Snake : IStatable
{
    private List<SnakePart> snakePartsList = new List<SnakePart>();
    private Vector2Int direction = new Vector2Int();

    public Vector2Int Direction { get; set; }
    public StateMachine StateMachine { get; }

    public Snake(Vector2Int position, Vector2Int direction, int snakeLength)
    {
        this.direction = direction;
        snakePartsList.Add(new SnakePart(position));
        for (int i = 1; i < snakeLength; i++)
        {
            snakePartsList.Add(new SnakePart(snakePartsList[i - 1].Position - direction));
        }
    }

    public void Move()
    {
        snakePartsList[0].Move(direction);
        for (int i = 1; i < snakePartsList.Count; i++)
        {
            if (snakePartsList[i].FrozenTime != 0)
            {
                snakePartsList[i].Move(snakePartsList[i - 1].Position);
            }
            else
            {
                snakePartsList[i].FrozenTime = -1;
            }
        }
    }

    public void Grow(float amount = 1)
    {
        for (int i = 0; i < Math.Floor(amount); i++)
        {
            snakePartsList.Add(new SnakePart(snakePartsList[snakePartsList.Count].Position, i + 1));
        }
    }
}