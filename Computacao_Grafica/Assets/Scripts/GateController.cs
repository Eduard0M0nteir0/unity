using UnityEngine;
using TMPro; // Needed for TextMeshPro

public class GateController : MonoBehaviour
{
    public bool isRightGate; // To indicate if the gate is the right one
    public TextMeshPro textMesh; // Reference to TextMeshPro component on the Quad
    private Animator playerAnimator;
    void Start() {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); 
        playerAnimator = player.GetComponent<Animator>();
        if (playerAnimator == null)
        {
            Debug.LogError("Animator component not found on the player.");
        }
    }

    public void SetAnswer(int answer)
    {
        // Display the number on the gate
        if (textMesh != null)
        {
            textMesh.text = answer.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // playerAnimator = GetComponent<Animator>();

        if (other.CompareTag("Player")) // Ensure your cube has the "Player" tag
        {
            if (isRightGate)
            {
                Debug.Log("Correct! You chose the right answer.");
                ScoreManager.instance.AddScore(1);
                playerAnimator.SetTrigger("Correct");
            }
            else
            {
                Debug.Log("Incorrect! You chose the wrong answer.");
                ScoreManager.instance.AddScore(-4);
                playerAnimator.SetTrigger("Wrong");
            }

            // After passing through a gate, generate a new math problem
            FindObjectOfType<MathGameController>().GenerateMathProblem();
        }
    }
}

