// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class PauseMenu : MonoBehaviour
// {
//     public GameObject pausePanel;

//     void Start()
//     {
//         // Make sure the game is running and pause panel is hidden
//         Time.timeScale = 1;
//         pausePanel.SetActive(false);
//     }

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Escape))
//         {
//             if (pausePanel.activeSelf)
//                 ResumeGame();
//             else
//                 PauseGame();
//         }
//     }

//     public void ResumeGame()
//     {
//         pausePanel.SetActive(false);
//         Time.timeScale = 1;
//     }

//     public void PauseGame()
//     {
//         pausePanel.SetActive(true);
//         Time.timeScale = 0;
//     }

//     public void RestartGame()
//     {
//         Time.timeScale = 1;
//         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//     }

//     public void ReturnToMainMenu()
//     {
//         Time.timeScale = 1;
//         SceneManager.LoadScene("MainMenuScene");
//     }
// }

// // using UnityEngine;
// // using UnityEngine.SceneManagement;

// // public class PauseMenu : MonoBehaviour
// // {
// //     public GameObject pausePanel;

// //     private bool isPaused = false;

// //     void Start()
// //     {
// //         Time.timeScale = 1f;
// //         if (pausePanel != null)
// //             pausePanel.SetActive(false);
// //     }

// //     void Update()
// //     {
// //         // Optional: Escape key fallback for desktop
// //         if (Input.GetKeyDown(KeyCode.Escape))
// //         {
// //             if (isPaused)
// //                 ResumeGame();
// //             else
// //                 PauseGame();
// //         }
// //     }

// //     // Called by UI Pause Button
// //     public void OnPauseButtonPressed()
// //     {
// //         if (!isPaused)
// //             PauseGame();
// //     }

// //     public void ResumeGame()
// //     {
// //         if (pausePanel != null)
// //             pausePanel.SetActive(false);

// //         Time.timeScale = 1f;
// //         isPaused = false;
// //     }

// //     public void PauseGame()
// //     {
// //         if (pausePanel != null)
// //             pausePanel.SetActive(true);

// //         Time.timeScale = 0f;
// //         isPaused = true;
// //     }

// //     public void RestartGame()
// //     {
// //         Time.timeScale = 1f;
// //         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
// //     }

// //     public void ReturnToMainMenu()
// //     {
// //         Time.timeScale = 1f;
// //         SceneManager.LoadScene("MainMenuScene");
// //     }
// // }

// New Script:

// PauseMenu.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Drag your PausePanel into this slot in the Inspector
    public GameObject pausePanel;

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }
}