using UnityEngine;

public class SnakePart : MonoBehaviour
{
    [SerializeField] private Vector3Int direction;
    
    public SnakePart previousPart;
    public SnakePart nextPart;
    public Vector3Int Direction => direction;

    public void SetDirection(Vector3Int value)
    {
        direction = value;
    }
}
