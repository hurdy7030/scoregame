using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public int highScore;
    static bool restarting;
    public bool losing;
    public bool started;

    public TMP_Text scoreText;
    public GameObject gameOverPanel;
    public TMP_Text startText;

    void Start()
    {
        started = restarting;
        restarting = false;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        startText.text = "Press E to start the game";
        UpdateText();
    }

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (losing)
            {
                restarting = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else if (!started)
            {
                started = true;
                UpdateText();
            }
        }
    }

    public void AddScore()
    {
        if (!started || losing)
            return;

        score++;
        UpdateText();
    }

    public void LoseGame()
    {
        if (!started || losing)
            return;

        losing = true;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
        UpdateText();
    }

    void UpdateText()
    {
        scoreText.text = score.ToString();
        startText.gameObject.SetActive(!started && !losing);
        gameOverPanel.GetComponent<TMP_Text>().text = "Game Over\nScore: " + score + "\nHigh Score: " + highScore + "\nPress E to restart";
        gameOverPanel.SetActive(losing);
    }
}
