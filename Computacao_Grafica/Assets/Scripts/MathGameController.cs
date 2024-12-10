using UnityEngine;
using TMPro; 

public class MathGameController : MonoBehaviour
{
    public TextMeshPro mathProblemText;
    public GateController rightGate;
    public GateController wrongGate;

    private int correctAnswer;

    void Start()
    {
        GenerateMathProblem();
    }

    public void GenerateMathProblem()
    {
        int number1 = 0;
        int number2 = 0;
        int incrementDifficulty = ScoreManager.instance.AddScore(0);

        string[] operators = { "+", "-", "*", "/" };
        string chosenOperator = operators[Random.Range(0, operators.Length)];

        switch (chosenOperator)
        {
            case "+":
                number1 = Random.Range(1 + incrementDifficulty, 50 + incrementDifficulty);
                number2 = Random.Range(1 + incrementDifficulty, 50 + incrementDifficulty);
                correctAnswer = number1 + number2;
                break;
            case "-":
                number1 = Random.Range(1 + incrementDifficulty, 50 + incrementDifficulty);
                number2 = Random.Range(1 + incrementDifficulty, 50 + incrementDifficulty);
                correctAnswer = number1 - number2;
                break;
            case "*":
                number1 = Random.Range(2 + incrementDifficulty, 10 + incrementDifficulty);
                number2 = Random.Range(2 + incrementDifficulty, 10 + incrementDifficulty);
                correctAnswer = number1 * number2;
                break;
            case "/":
                number1 = Random.Range(2 + incrementDifficulty, 10 + incrementDifficulty);
                number2 = Random.Range(2 + incrementDifficulty, 10 + incrementDifficulty);
                number1 = number1 * number2;
                correctAnswer = number1 / number2;
                break;
        }

        mathProblemText.text = number1 + " " + chosenOperator + " " + number2 + " = ?";

        ShuffleGatesWithAnswers();
        //mathProblemText.text = "";
    }

    void ShuffleGatesWithAnswers()
    {
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

        rightGate.isRightGate = randomIndex == 0;
        wrongGate.isRightGate = randomIndex == 1;
    }
}
