using UnityEngine;

public class SnakePart
{
    private Vector2Int position;

    public int FrozenTime;
    public Vector2Int Position { get; }

    public SnakePart(Vector2Int position, int frozenTime = 0)
    {
        this.position = position;
        FrozenTime = frozenTime;
    }

    public void Move(Vector2Int direction)
    {
        position += direction;
    }
}