using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public GameObject gamePanel;

    [Header("Buttons")]
    public GameObject pauseButton;
    public GameObject exitButton;
    public GameObject audioButton;

    [Header("Texts")]
    public Text finalScoreText;
    public Text audioText;

    [Header("Score")]
    public Score score;

    [Header("Bools")]
    public bool isEnd = false;
    public bool isMuted = false;
    public void GameOver()
    {
        isEnd = true;
        Debug.Log("Game over");
        gameOverPanel.SetActive(true);
        pauseButton.SetActive(false);
        finalScoreText.text = "FINAL SCORE:\n" + score.currentScore.ToString();
        score.scoreText.text = " ";
        audioButton.SetActive(false);
        isMuted = !isMuted;
        AudioListener.pause = isMuted;

    }
    public void RestartButton()
    {
        SceneManager.LoadScene(0);
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
    }
    public void PauseButton()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        pauseButton.SetActive(false);
    }

    public void ContButton()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        pauseButton.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Leave Application");
    }
    public void AudioButton()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        if(isMuted==true)
        {
            audioText.text = "Unmute";
        }
        if (isMuted == false)
        {
            audioText.text = "Mute";
        }
    }

}
