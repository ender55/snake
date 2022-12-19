using UnityEngine;

public class SinglePlayerSpawner : MonoBehaviour
{
    [SerializeField] private SnakePart snakePartPrefab;
    [SerializeField] private Vector3Int spawnDirection;
    [SerializeField] private Vector3Int spawnPosition;
    [SerializeField] private int spawnLength;
    [SerializeField] private PlayerKeyCodes playerKeyCodes;
    [SerializeField] private SnakeViewData snakeViewData;
    
    private SnakeBuilder snakeBuilder = new SnakeBuilder();
    private Snake snake;

    private void Awake()
    {
        Time.timeScale = 0.1f;
    }

    private void Start()
    {
        snake = snakeBuilder.CreateSnake(snakePartPrefab, spawnDirection, spawnPosition, spawnLength, playerKeyCodes, snakeViewData);
        snake.OnGrowth += snakeBuilder.AddSnakePart;
    }

    private void OnDisable()
    {
        snake.OnGrowth -= snakeBuilder.AddSnakePart;
    }
}