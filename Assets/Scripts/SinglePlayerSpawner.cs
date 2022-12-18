﻿using UnityEngine;

public class SinglePlayerSpawner : MonoBehaviour
{
    [SerializeField] private SnakePart snakePartPrefab;
    [SerializeField] private Vector3Int spawnDirection;
    [SerializeField] private Vector3Int spawnPosition;
    [SerializeField] private int spawnLength;
    [SerializeField] private PlayerKeyCodes playerKeyCodes;

    private SnakeBuilder snakeBuilder = new SnakeBuilder();

    private void Start()
    {
        Snake snake = snakeBuilder.CreateSnake(snakePartPrefab, spawnDirection, spawnPosition, spawnLength, playerKeyCodes);
    }
}