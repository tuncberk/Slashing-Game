using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    public static GUIManager instance;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    public Text scoreTotal;
    public Text itemTotal;
    public Text itemDestroyed;

    public Text scoreTxt;
    private int score;
    public bool isPaused = false;

    // Use this for initialization
    void Awake()
    {
        instance = GetComponent<GUIManager>();
    }
    public void upgradeScore(int increment)
    {
        score += increment;
        scoreTxt.text = score.ToString();
    }
    public void activatePauseMenu()
    {
        if (isPaused)
        {
            resumeGame();
        }
        else
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void resumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void returnToMain()
    {
      Time.timeScale = 1f;
      SceneManager.LoadScene("MainMenu");
    }
    public void activateGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
}
