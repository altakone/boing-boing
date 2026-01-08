using UnityEngine;
using UnityEngine.SceneManagement; // Needed to load the game scene

public class MainMenuController : MonoBehaviour
{
    [Header("Panels to Open")]
    public GameObject shopPanel;        // The window for Skins
    public GameObject leaderboardPanel; // The window for High Scores

    // BUTTON 1: PLAY
    public void PlayGame()
    {
        // Loads the next scene in the list (your actual game)
        // Ensure your Game Scene is added in 'File -> Build Settings'
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // BUTTON 2: SKIN SHOP
    public void ToggleShop(bool show)
    {
        shopPanel.SetActive(show);
    }

    // BUTTON 3: LEADERBOARD
    public void ToggleLeaderboard(bool show)
    {
        leaderboardPanel.SetActive(show);
    }

    // BUTTON 4: QUIT
    public  void QuitGame()
    {
        Debug.Log("Quitting Game...");
        try
        {
         Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
        catch (System.Exception e)
        {
            Debug.Log("Exception caught while quitting: " + e.Message);
        }

    }
}