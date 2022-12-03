using System;
using System.Collections.Generic;
using UnityEngine;

public class Snake : IStatable
{
    public List<SnakePart> SnakePartsList { get; }
    private Vector2Int direction;

    public Vector2Int Direction { get; set; }
    public StateMachine StateMachine { get; }

    public Snake(Vector2Int position, int snakeLength)
    {
        SnakePartsList = new List<SnakePart>();
        SnakePartsList.Add(new SnakePart(position));
        for (int i = 1; i < snakeLength; i++)
        {
            SnakePartsList.Add(new SnakePart(SnakePartsList[i - 1].Position - direction));
        }
    }

    public void Move()
    {
        SnakePartsList[0].Move(direction);
        for (int i = 1; i < SnakePartsList.Count; i++)
        {
            if (SnakePartsList[i].FrozenTime != 0)
            {
                SnakePartsList[i].Move(SnakePartsList[i - 1].Position);
            }
            else
            {
                SnakePartsList[i].FrozenTime = -1;
            }
        }
    }

    public void Grow(float amount = 1)
    {
        for (int i = 0; i < Math.Floor(amount); i++)
        {
            SnakePartsList.Add(new SnakePart(SnakePartsList[SnakePartsList.Count].Position, i + 1));
        }
    }
}