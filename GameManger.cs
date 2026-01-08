using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;
//public class GameManger : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}


//public class GameManager : MonoBehaviour
//{
//    public static GameManager Instance;

//    // Data Variables
//    public int totalMoney;
//    public int highScore;

//    // States
//    public bool isGameActive = false;

//    private void Awake()
//    {
//        // Singleton Pattern
//        if (Instance == null)
//        {
//            Instance = this;
//            DontDestroyOnLoad(gameObject); // Keeps this object alive between scenes
//            LoadData(); // Load saved data on startup
//        }
//        else
//        {
//            Destroy(gameObject);
//        }
//    }

//    // --- SAVE SYSTEM (PlayerPrefs) ---
//    public void SaveData()
//    {
//        PlayerPrefs.SetInt("TotalMoney", totalMoney);
//        PlayerPrefs.SetInt("HighScore", highScore);
//        PlayerPrefs.Save();
//    }

//    public void LoadData()
//    {
//        totalMoney = PlayerPrefs.GetInt("TotalMoney", 0); // Default 0
//        highScore = PlayerPrefs.GetInt("HighScore", 0);
//    }

//    public void AddMoney(int amount)
//    {
//        totalMoney += amount;
//        SaveData();
//    }

//    // --- GAME FLOW ---
//    public void StartGame()
//    {
//        isGameActive = true;
//        Time.timeScale = 1;
//        // Logic to spawn player or reset position goes here
//    }

//    public void GameOver()
//    {
//        isGameActive = false;
//        Time.timeScale = 0; // Stop the game

//        // Check High Score
//        // (In a real scenario, you'd pass the current run score here)
//        int currentRunScore = 0; // Placeholder
//        if (currentRunScore > highScore)
//        {
//            highScore = currentRunScore;
//            SaveData();
//        }
//    }
//}
