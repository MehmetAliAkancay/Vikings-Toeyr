using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameIsEnded = false;
    public GameObject dieMenu;
    public GameObject winMenu;
    public void WinGame()
    {
        if (!gameIsEnded)
        {
            gameIsEnded = true;
            Time.timeScale = 0;
            winMenu.SetActive(true);
        }
    }
    public void LoseGame()
    {
        if(!gameIsEnded)
        {
            gameIsEnded = true;
            Time.timeScale = 0;
            dieMenu.SetActive(true);
        } 
    }
    public void Restart()
    {
        gameIsEnded = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScene");
        Time.timeScale = 1;
        gameIsEnded = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
