using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void OnCreditsButton()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void OnQuitButton()
    {
        Application.Quit(); // Quits standalone builds
        Debug.Log("Game Quit");
    }
}
