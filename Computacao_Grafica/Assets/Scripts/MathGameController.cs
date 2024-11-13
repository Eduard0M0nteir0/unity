using UnityEngine;
using TMPro; // Needed for TextMeshPro

public class MathGameController : MonoBehaviour
{
    public TextMeshPro mathProblemText; // Text at the top of the screen for the math problem
    public GateController rightGate;
    public GateController wrongGate;

    private int correctAnswer;

    // Start is called before the first frame update
    void Start()
    {
        GenerateMathProblem();
    }

    // Generates a random math problem and updates gates with answers
    public void GenerateMathProblem()
    {
        // Generate two random numbers for the math problem
        int number1 = 0;
        int number2 = 0;
        int incrementDifficulty = ScoreManager.instance.returnScore();

        // Pick a random operator
        string[] operators = { "+", "-", "*", "/" };
        string chosenOperator = operators[Random.Range(0, operators.Length)];

        // Calculate the correct answer based on the operator
        switch (chosenOperator)
        {
            case "+":
                number1 = Random.Range(1 + incrementDifficulty, 100 + incrementDifficulty);
                number2 = Random.Range(1 + incrementDifficulty, 100 + incrementDifficulty);
                correctAnswer = number1 + number2;
                break;
            case "-":
                number1 = Random.Range(1 + incrementDifficulty, 100 + incrementDifficulty);
                number2 = Random.Range(1 + incrementDifficulty, 100 + incrementDifficulty);
                correctAnswer = number1 - number2;
                break;
            case "*":
                number1 = Random.Range(2 + incrementDifficulty, 20 + incrementDifficulty);
                number2 = Random.Range(2 + incrementDifficulty, 20 + incrementDifficulty);
                correctAnswer = number1 * number2;
                break;
            case "/":
                number1 = Random.Range(2 + incrementDifficulty, 20 + incrementDifficulty);
                number2 = Random.Range(2 + incrementDifficulty, 20 + incrementDifficulty);
                number1 = number1 * number2;
                correctAnswer = number1 / number2;
                break;
        }

        // Display the math problem at the top of the screen
        mathProblemText.text = number1 + " " + chosenOperator + " " + number2 + " = ?";

        // Shuffle the answers between the gates
        ShuffleGatesWithAnswers();
        //mathProblemText.text = "";
    }

    // Shuffles correct answer and a random wrong answer between gates
    void ShuffleGatesWithAnswers()
    {
        // Randomly decide which gate is correct
        int randomIndex = Random.Range(0, 2);
        int randomOperation = Random.Range(0, 2);
        int randomOffSet = Random.Range(1, 11);
        if (randomIndex == 0)
        {
            rightGate.SetAnswer(correctAnswer);
            
            if (randomOperation == 0) {
                wrongGate.SetAnswer(correctAnswer + randomOffSet); 
            }
            else {
                wrongGate.SetAnswer(correctAnswer - randomOffSet);
            }
        }
        else
        {
            if (randomOperation == 0) {
                rightGate.SetAnswer(correctAnswer + randomOffSet); 
            }
            else {
                rightGate.SetAnswer(correctAnswer - randomOffSet); 
            }
            wrongGate.SetAnswer(correctAnswer); 
        }

        // Set the correct gate in each GateController
        rightGate.isRightGate = randomIndex == 0;
        wrongGate.isRightGate = randomIndex == 1;
    }
}
