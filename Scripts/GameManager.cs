using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Needed for reloading scene

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int totalMoney;
    public bool isGameActive = false;

    // Drag your "Game Over UI Panel" here in Inspector
    public GameObject gameOverPanel;

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); LoadData(); }
        else { Destroy(gameObject); }
    }

    public void AddMoney(int amount)
    {
        totalMoney += amount;
        SaveData(); // Save immediately when getting money
    }

    public void GameOver()
    {
        isGameActive = false;
        Time.timeScale = 0; // Freeze the game

        // Show the Game Over Menu
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        // Unfreeze time
        Time.timeScale = 1;

        // Hide panel
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        // Reload the currently active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        isGameActive = true;
    }

    private void LoadData()
    {
        // Implement your data loading logic here
        // For example:
        // totalMoney = PlayerPrefs.GetInt("TotalMoney", 0);
    }
    private void SaveData()
    {
        // Implement your data saving logic here
        // For example:
        // PlayerPrefs.SetInt("TotalMoney", totalMoney);
        // PlayerPrefs.Save();
    }
}