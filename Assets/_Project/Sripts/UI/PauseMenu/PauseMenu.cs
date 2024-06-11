using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]    
    private GameObject pauseMenu;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ReStartGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void ReTryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void ReStartBtn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
