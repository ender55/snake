using System;
using UnityEngine;

class SnakePartMovement : IMovement
{
    private SnakePart snakePart;
    
    public SnakePartMovement(SnakePart snakePart)
    {
        this.snakePart = snakePart;
    }
    
    public void Move()
    {
        if (snakePart.previousPart != null)
        {
            int x = Convert.ToInt32(snakePart.previousPart.transform.position.x - snakePart.transform.position.x);
            int y = Convert.ToInt32(snakePart.previousPart.transform.position.y - snakePart.transform.position.y);
            snakePart.SetDirection(new Vector3Int(x, y, 0));
            snakePart.transform.position += snakePart.Direction;
        }
    }
}