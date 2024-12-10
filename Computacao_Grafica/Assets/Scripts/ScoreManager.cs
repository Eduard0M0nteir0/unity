using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText; 
    private int score = 5; 
    //private int maxScore = 1;
    private Animator playerAnimator;

    void Start() {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); 
        playerAnimator = player.GetComponent<Animator>();
        if (playerAnimator == null)
        {
            Debug.LogError("Animator component not found on the player.");
        }
    }

    void Awake()
    {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public int AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();
        return score;
    }
}
