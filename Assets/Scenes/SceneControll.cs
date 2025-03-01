using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Load một scene theo tên
    public void LoadScene()
    {
        SceneManager.LoadScene("Login");
    }

    // Load Main Menu
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Start");
    }

    // Load Game
    public void LoadGame()
    {
        SceneManager.LoadScene("Play");
    }

    // Thoát game
    public void QuitGame()
    {
        Debug.Log("Thoát game!");
        Application.Quit();
    }
}
