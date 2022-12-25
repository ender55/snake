using UnityEngine;

public class SnakeView
{
    private SnakeViewData snakeViewData;

    public SnakeView(SnakeViewData snakeViewData)
    {
        this.snakeViewData = snakeViewData;
    }

    public void Draw(SnakePart tail)
    {
        bool isHead = false;
        while (!isHead)
        {
            tail.SpriteRenderer.flipY = false;
            if (tail.nextPart == null)
            {
                tail.SpriteRenderer.sprite = snakeViewData.TailTile;
            }
            else if (tail.previousPart == null)
            {
                tail.SpriteRenderer.sprite = snakeViewData.HeadTile;
                isHead = true;
            }
            else
            {
                if (IsRightAngle(tail))
                {
                    tail.SpriteRenderer.sprite = snakeViewData.AngleRBodyTile;
                    tail.SpriteRenderer.flipY = true;
                }
                else if (IsLeftAngle(tail))
                {
                    tail.SpriteRenderer.sprite = snakeViewData.AngleLBodyTile;
                    tail.SpriteRenderer.flipY = true;
                }
                else
                {
                    tail.SpriteRenderer.sprite = snakeViewData.StraightBodyTile;
                }
            }

            FlipSprite(tail);
            tail = tail.previousPart;
        }
    }

    private bool IsRightAngle(SnakePart snakePart)
    {
        var tempX = snakePart.transform.position.x + snakePart.Direction.y;
        var tempY = snakePart.transform.position.y - snakePart.Direction.x;
        var nextPartX = snakePart.nextPart.transform.position.x;
        var nextPartY = snakePart.nextPart.transform.position.y;
        if (nextPartX == tempX && nextPartY == tempY)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool IsLeftAngle(SnakePart snakePart)
    {
        var tempX = snakePart.transform.position.x - snakePart.Direction.y;
        var tempY = snakePart.transform.position.y + snakePart.Direction.x;
        var nextPartX = snakePart.nextPart.transform.position.x;
        var nextPartY = snakePart.nextPart.transform.position.y;
        if (nextPartX == tempX && nextPartY == tempY)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void FlipSprite(SnakePart snakePart)
    {
        if (snakePart.Direction.y == 1)
        {
            snakePart.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (snakePart.Direction.y == -1)
        {
            snakePart.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (snakePart.Direction.x == -1)
        {
            snakePart.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (snakePart.Direction.x == 1)
        {
            snakePart.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }
}