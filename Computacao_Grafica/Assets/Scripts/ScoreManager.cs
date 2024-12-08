using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText; 
    private int score = 1; 

    void Awake()
    {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private IEnumerator LoadMenuAfterDelay(float delay) {
        yield return new WaitForSeconds(delay); 
        SceneManager.LoadScene("Menu"); 
    }

    public void checkDeath(int score) {
        if (score <= 0)
        {
            SceneManager.LoadScene("Menu"); 
            // StartCoroutine(LoadMenuAfterDelay(2f));
        }
    }


    public void AddScore(int points)
    {
        score += points;
        // Invoke(() => checkDeath(score), 3f);
        scoreText.text = "Score: " + score.ToString();
    }

    public int returnScore()
    {
        return score;
    }
}
