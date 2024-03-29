using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    public void LoadScene(String scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Enable(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
    
    public void Disable(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
