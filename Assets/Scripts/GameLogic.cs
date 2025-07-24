using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class GameLogic : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public Button rockBtn, paperBtn, scissorsBtn;

    private string[] choices = { "Rock", "Paper", "Scissors" };

    public void PlayerChoice(string playerMove)
    {
        DisableButtons(); // prevent spam/click cheating

        string computerMove = choices[Random.Range(0, choices.Length)];
        string outcome = GetResult(playerMove, computerMove);

        resultText.text = $"You chose: {playerMove}\nComputer chose: {computerMove}\n\n{outcome}";

        StartCoroutine(EnableButtonsAfterDelay(1.5f)); // wait then re-enable
    }

    private string GetResult(string player, string computer)
    {
        if (player == computer) return "It's a Draw!";
        if ((player == "Rock" && computer == "Scissors") ||
            (player == "Paper" && computer == "Rock") ||
            (player == "Scissors" && computer == "Paper"))
        {
            return "You Win!";
        }
        return "You Lose!";
    }

    private void DisableButtons()
    {
        rockBtn.interactable = false;
        paperBtn.interactable = false;
        scissorsBtn.interactable = false;
    }

    private IEnumerator EnableButtonsAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        rockBtn.interactable = true;
        paperBtn.interactable = true;
        scissorsBtn.interactable = true;
    }
}
