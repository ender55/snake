using System;
using UnityEngine;

public class SnakePart : MonoBehaviour, IMovable
{
    [SerializeField] private Vector3Int direction;

    public IMovement Movement { get; set; } = new Movement();
    
    public SnakePart previousPart;
    public SnakePart nextPart;
    public Vector3Int Direction => direction;

    private void Start()
    {
        SetDirectionUsingPreviousPart();
        //StartCoroutine(new WaitForSeconds(1));
    }

    private void FixedUpdate()
    {
        Movement.Move(transform, direction);
        SetDirectionUsingPreviousPart();
    }

    private void SetDirectionUsingPreviousPart()
    {
        if (previousPart != null)
        {
            var temp = Vector3Int.RoundToInt(previousPart.transform.position - transform.position);
            SetDirection(temp);
        }
    }
    
    public void SetDirection(Vector3Int value)
    {
        direction = value;
    }
}
