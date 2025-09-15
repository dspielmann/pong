using UnityEngine;
using TMPro;

public class scoreScript : MonoBehaviour
{
    public int scoreLeft = 0;          // P1 score
    public int scoreRight = 0;         // P2 score
    public TMP_Text scoreTextLeft;     // P1 Text
    public TMP_Text scoreTextRight;    // P2 Text
    public TMP_Text gameOverText;      // UI Text for Game Over

    public int winningScore = 5;       // score needed to win

    private bool gameOver = false;

    void Start()
    {
        UpdateScoreUI();
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);
    }

    public void AddPointLeft(int value)
    {
        if (gameOver) return;          // ignore after game over

        scoreLeft += value;
        UpdateScoreUI();
        CheckGameOver();
    }

    public void AddPointRight(int value)
    {
        if (gameOver) return;          // ignore after game over

        scoreRight += value;
        UpdateScoreUI();
        CheckGameOver();
    }

    void UpdateScoreUI()
    {
        if (scoreTextLeft != null)
            scoreTextLeft.text = "P1: " + scoreLeft;
        if (scoreTextRight != null)
            scoreTextRight.text = "P2: " + scoreRight;
    }

    void CheckGameOver()
    {
        if (scoreLeft >= winningScore)
        {
            GameOver("Player 1 Wins!");
        }
        else if (scoreRight >= winningScore)
        {
            GameOver("Player 2 Wins!");
        }
    }

    void GameOver(string message)
    {
        gameOver = true;

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = message;
        }

        // Optional: stop time
        Time.timeScale = 0f;
    }

    public void ResetScores()
    {
        gameOver = false;
        scoreLeft = 0;
        scoreRight = 0;
        UpdateScoreUI();
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);

        Time.timeScale = 1f; // resume time
    }
}
