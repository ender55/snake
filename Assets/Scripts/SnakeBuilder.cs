using UnityEngine;

public class SnakeBuilder
{
    
    public Snake CreateSnake(SnakePart snakePartPrefab, Vector3Int direction, Vector3Int position, int length, PlayerKeyCodes playerKeyCodes)
    {
        var snakeGameObject = new GameObject("Snake", typeof(Snake));
        var snake = GameObject.Instantiate(snakeGameObject,
            position, Quaternion.Euler(direction)).GetComponent<Snake>();
        GameObject.Destroy(snakeGameObject);
        CreateSnakePart(snakePartPrefab, position, direction, snake, false);
        for (int i = 1; i < length; i++)
        {
            CreateSnakePart(snakePartPrefab, position - direction * i, direction, snake);
        }

        snake.MovementInputController.PlayerKeyCodes = playerKeyCodes;
        snake.MovementInputController.Direction = direction;
        return snake;
    }

    private SnakePart CreateSnakePart(SnakePart snakePartPrefab, Vector3Int position, Vector3Int direction, Snake snake, bool hasCollider = true)
    {
        var snakePart = GameObject.Instantiate(snakePartPrefab, position, Quaternion.Euler(direction));
        if (snake.Head == null)
        {
            snake.Head = snakePart;
        }
        else
        {
            snake.Tail.nextPart = snakePart;
            snakePart.previousPart = snake.Tail;
        }

        snake.Tail = snakePart;
        
        if (hasCollider)
        {
            var collider = snakePart.gameObject.AddComponent<BoxCollider2D>();
            collider.size = new Vector2(0.8f, 0.8f);
        }

        return snakePart;
    }
}