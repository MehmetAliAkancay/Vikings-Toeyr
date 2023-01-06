using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScene");
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void WinGame()
    {

    }
    public void LoseGame()
    {

    }
}
