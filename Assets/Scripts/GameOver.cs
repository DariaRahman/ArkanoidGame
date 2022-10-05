using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _gameOver = null;
    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void OpenGameOverMenu()
    {
        _gameOver.SetActive(true);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _gameOver.SetActive(false);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}