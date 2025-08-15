using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsUI : MonoBehaviour
{
    public void OnBackToMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
