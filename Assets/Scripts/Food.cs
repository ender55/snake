using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Food : MonoBehaviour
{
    [SerializeField] private Transform transform;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private Rigidbody2D rigidbody2D;

    [SerializeField] private List<Sprite> foodSprites;

    [SerializeField] private int topBorder;
    [SerializeField] private int bottomBorder;
    [SerializeField] private int leftBorder;
    [SerializeField] private int rightBorder;

    private void Start()
    {
        transform = gameObject.GetComponent<Transform>();
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        boxCollider2D = gameObject.AddComponent<BoxCollider2D>();
        boxCollider2D.size = new Vector2(0.5f, 0.5f);
        rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 0;
        ResetPosition();
        ChangeSprite();
    }

    private void ResetPosition()
    {
        int x = Random.Range(leftBorder, rightBorder);
        int y = Random.Range(bottomBorder, topBorder);
        transform.position = new Vector3(x, y, 0);
    }

    private void ChangeSprite()
    {
        if (foodSprites.Count != 0)
        {
            int index = Random.Range(0, foodSprites.Count);
            spriteRenderer.sprite = foodSprites[index];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ResetPosition();
        ChangeSprite();
    }
}