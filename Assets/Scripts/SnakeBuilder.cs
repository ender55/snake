using UnityEngine;

public class SnakeBuilder
{
    public Snake CreateSnake(SnakePart snakePartPrefab, Vector3Int direction, Vector3Int position, int length,
        PlayerKeyCodes playerKeyCodes, SnakeViewData snakeViewData)
    {
        var snakeGameObject = new GameObject("Snake", typeof(Snake));
        var snake = GameObject.Instantiate(snakeGameObject, position, Quaternion.Euler(direction))
            .GetComponent<Snake>();
        GameObject.Destroy(snakeGameObject);
        snake.SnakeViewData = snakeViewData;
        CreateSnakePart(snakePartPrefab, position, direction, snake, false);
        for (int i = 1; i < length; i++)
        {
            CreateSnakePart(snakePartPrefab, position - direction * i, direction, snake);
        }

        snake.MovementInputController.PlayerKeyCodes = playerKeyCodes;
        snake.MovementInputController.Direction = direction;
        return snake;
    }

    public void CreateSnakePart(SnakePart snakePartPrefab, Vector3Int position, Vector3Int direction, Snake snake,
        bool hasCollider = true)
    {
        var snakePart = GameObject.Instantiate(snakePartPrefab, position, Quaternion.identity);
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

        snakePart.SetDirection(direction);
        snakePart.SnakeViewData = snake.SnakeViewData;
    }

    public void AddSnakePart(SnakePart snakePartPrefab, Snake snake)
    {
        Vector3Int angle;
        if (snakePartPrefab.Direction.x == -1)
        {
            angle = new Vector3Int(0, 0, 90);
        }
        else if (snakePartPrefab.Direction.x == 1)
        {
            angle = new Vector3Int(0, 0, -90);
        }
        else if (snakePartPrefab.Direction.y == -1)
        {
            angle = new Vector3Int(0, 0, 180);
        }
        else
        {
            angle = new Vector3Int(0, 0, 0);
        }

        var snakePart = GameObject.Instantiate(snakePartPrefab, snakePartPrefab.transform.position, Quaternion.Euler(angle));
        snake.Tail.nextPart = snakePart;
        snakePart.previousPart = snake.Tail;
        snake.Tail = snakePart;

        var collider = snakePart.gameObject.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(0.8f, 0.8f);

        snakePart.SetDirection(Vector3Int.zero);
        snakePart.SnakeViewData = snake.SnakeViewData;
    }
}