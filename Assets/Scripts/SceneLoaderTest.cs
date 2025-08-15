using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderTest : MonoBehaviour
{
    public void TestLoadMyScene()
    {
        Debug.Log("TEST SCRIPT: Attempting to load PauseMenuScene...");
        SceneManager.LoadScene("PauseMenuScene", LoadSceneMode.Additive);
    }
}