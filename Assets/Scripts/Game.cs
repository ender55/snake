using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    private Snake snake;
    private GameField gameField;

    private void Awake()
    {
        snake = new Snake(new Vector2Int(3, 3), 2);
        gameField = new GameField();
    }

    private void Start()
    {
        //draw map
    }

    private void Run()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            snake.Direction = Vector2Int.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            snake.Direction = Vector2Int.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            snake.Direction = Vector2Int.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            snake.Direction = Vector2Int.right;
        }

        snake.Move();
        
        if (gameField.Field[snake.SnakePartsList[0].Position.x, snake.SnakePartsList[0].Position.y].CurrentState ==
            Cell.States.Food)
        {
            snake.Grow();
        }
        else if (gameField.Field[snake.SnakePartsList[0].Position.x, snake.SnakePartsList[0].Position.y].CurrentState ==
                 Cell.States.Wall)
        {
            //game over
        }
        //draw snake
    }
}