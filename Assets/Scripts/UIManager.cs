using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI ballsText;

    private GameManager gameManager;

    private int currentScore = 0;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        UpdateScoreDisplay();
        UpdateLivesDisplay();
    }

    public void AddScore(int points)
    {
        currentScore += points;
        UpdateScoreDisplay();
    }

    public void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Scores: {currentScore}";
        }
    }

    public void UpdateLivesDisplay()
    {
        if(ballsText != null)
        {
            ballsText.text = $"Balls: {gameManager.remainingBalls}";
        }
    }

    public void ResetScoreDisplay()
    {
        if (scoreText != null)
        {
            currentScore = 0;
            scoreText.text = $"Score: {currentScore}";
        }
    }

    public void ResetLivesDisplay()
    {
        if (ballsText != null)
        {
            ballsText.text = $"Balls: {gameManager.remainingBalls}";
        }
    }
}