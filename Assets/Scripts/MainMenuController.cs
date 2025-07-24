using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame() => SceneManager.LoadScene("GameScene");
    public void OpenSettings() => SceneManager.LoadScene("Settings");
    public void OpenHowToPlay() => SceneManager.LoadScene("HowToPlay");
    public void OpenAbout() => SceneManager.LoadScene("About");
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // For Editor
#else
        Application.Quit(); // For build
#endif
    }
}
