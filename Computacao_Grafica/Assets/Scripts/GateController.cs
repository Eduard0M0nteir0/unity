using UnityEngine;
using TMPro; 

public class GateController : MonoBehaviour
{
    public bool isRightGate; 
    public TextMeshPro textMesh; 
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

        if (other.CompareTag("Player"))
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

            FindObjectOfType<MathGameController>().GenerateMathProblem();
        }
    }
}

