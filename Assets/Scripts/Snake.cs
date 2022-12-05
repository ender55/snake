using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private int snakeSize = 3;
    [SerializeField] private Vector3Int spawnPosition;
    [SerializeField] private Vector3Int direction;

    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode down;
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode right;

    [SerializeField] private GameObject snakePartPrefab;
    [SerializeField] private bool isOnline;

    [SerializeField] private Sprite HeadSprite;
    [SerializeField] private Sprite StraightBodySprite;
    [SerializeField] private Sprite AngleRBodySprite;
    [SerializeField] private Sprite AngleLBodySprite;
    [SerializeField] private Sprite TailSprite;

    [SerializeField] private GameObject GameOverScreen;
    
    private List<GameObject> snakeParts = new List<GameObject>();
    private Vector3 lastPosition;
    private BoxCollider2D boxCollider2D;
    private Rigidbody2D rigidbody2D;
    private PhotonView photonView;

    public event Action OnDeath;
    
    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        spawnPosition.x = (int) gameObject.transform.position.x;
        spawnPosition.y = (int) gameObject.transform.position.y;
        spawnPosition.z = 0;
        boxCollider2D = gameObject.AddComponent<BoxCollider2D>();
        boxCollider2D.size = new Vector2(0.5f, 0.5f);
        boxCollider2D.isTrigger = true;
        rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 0f;
        Reset();
        Draw();
        StartCoroutine(Wait());
    }

    private void Update()
    {
        if (!isOnline)
        {
            CheckInput();
        }
        else
        {
            if (photonView.IsMine)
            {
                CheckInput();
            }
        }
    }

    private void CheckInput()
    {
        if (direction.x != 0)
        {
            if (Input.GetKeyDown(up))
            {
                direction = new Vector3Int(0, 1, 0);
            }
            else if (Input.GetKeyDown(down))
            {
                direction = new Vector3Int(0, -1, 0);
            }
        }
        else if (direction.y != 0)
        {
            if (Input.GetKeyDown(left))
            {
                direction = new Vector3Int(-1, 0, 0);
            }
            else if (Input.GetKeyDown(right))
            {
                direction = new Vector3Int(1, 0, 0);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isOnline)
        {
            Move();
        }
        else
        {
            if (photonView.IsMine)
            {
                Move();
            }
        }

        Time.timeScale += 0.00005f;
    }

    private void Move()
    {
        lastPosition = snakeParts[snakeParts.Count - 1].transform.position;
        for (int i = snakeParts.Count - 1; i > 0; i--)
        {
            snakeParts[i].transform.position = snakeParts[i - 1].transform.position;
        }

        snakeParts[0].transform.position += direction;
        gameObject.transform.position = snakeParts[0].transform.position;
    }

    private void Grow()
    {
        snakeParts.Add(CreateSnakePart(lastPosition));
        Draw();
    }

    private void Reset()
    {
        foreach (var part in snakeParts)
        {
            Destroy(part);
        }

        snakeParts.Clear();
        snakeParts.Add(CreateSnakePart(spawnPosition, false));
        for (int i = 1; i < snakeSize; i++)
        {
            snakeParts.Add(CreateSnakePart(snakeParts[i - 1].transform.position - direction));
        }

        Time.timeScale = 0.1f;
        Draw();
    }

    private void Draw()
    {
        foreach (var part in snakeParts)
        {
            SpriteRenderer spriteRenderer = part.gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = StraightBodySprite;
        }
    }

    private GameObject CreateSnakePart(Vector3 position, bool hasCollider = true)
    {
        GameObject snakePart = Instantiate(snakePartPrefab);
        //snakePart.AddComponent<SpriteRenderer>();
        if (!hasCollider)
        {
            snakePart.GetComponent<BoxCollider2D>().enabled = false;
        }
        snakePart.transform.position = position;
        return snakePart;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Food component))
        {
            Grow();
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        foreach (var part in snakeParts)
        {
            Destroy(part);
        }
        snakeParts.Clear();
        OnDeath?.Invoke();
        GameOverScreen.SetActive(true);
    }

    private IEnumerator Wait()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 0.1f;
    }
}