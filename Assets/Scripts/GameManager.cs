using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum Choice { Rock, Paper, Scissors }

    [Header("UI Text References")]
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI playerChoiceText;
    public TextMeshProUGUI computerChoiceText;

    // Called when player clicks a button
    public void PlayerMakesChoice(int choice)
    {
        Choice player = (Choice)choice;
        Choice computer = (Choice)Random.Range(0, 3);

        playerChoiceText.text = "Player: " + player.ToString();
        computerChoiceText.text = "Computer: " + computer.ToString();

        string result = DetermineWinner(player, computer);
        resultText.text = result;
    }

    // Logic to determine winner
    string DetermineWinner(Choice player, Choice computer)
    {
        if (player == computer)
            return "Draw!";

        if ((player == Choice.Rock && computer == Choice.Scissors) ||
            (player == Choice.Paper && computer == Choice.Rock) ||
            (player == Choice.Scissors && computer == Choice.Paper))
        {
            return "You Win!";
        }

        return "Computer Wins!";
    }

    // Reset game to initial state
    public void PlayAgain()
    {
        resultText.text = "Make your choice!";
        playerChoiceText.text = "";
        computerChoiceText.text = "";
    }

    // Back button support
    public void GoBackToMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Change "MainMenu" if needed
    }
}
