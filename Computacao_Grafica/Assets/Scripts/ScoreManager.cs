using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton for global access
    public TextMeshProUGUI scoreText; // UI element to display the score
    private int score = 5; // The player's score

    void Awake()
    {
        // Make this the singleton instance
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    // Method to increase score
    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();
    }

    // Optionally, reset the score
    public void ResetScore()
    {
        score = 0;
        scoreText.text = "Score: 0";
    }

    public int returnScore()
    {
        return score;
    }
}
