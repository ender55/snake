using System;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;

    private void Start()
    {
        Disable();
    }

    private void OnEnable()
    {
        Snake.OnDeath += Activate;
    }

    private void OnDisable()
    {
        Snake.OnDeath -= Activate;
    }

    private void Activate()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
    
    private void Disable()
    {
        gameOverScreen.SetActive(false);
    }
}
