using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    
    public void QuitGame()
    {
        Debug.Log("Oyundan cikildi!");
        Application.Quit();
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
