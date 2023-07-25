using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePlay : MonoBehaviour
{
    [SerializeField] public string sceneToLoad; // next level
    public static bool tryAgain = false;
    private void OnTriggerEnter2D(Collider2D other) // 
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            Debug.Log("Reset Key");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
    public void PlayGame()    // Load Scene for button click
    {
        SceneManager.LoadScene("Scene00_1");
    }
    public void QuitGame()    // Exit Game Botton click
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("Scene00");
    }

    public void MenuButton()  // Return Map
    {
        SceneManager.LoadScene("Scene00_1");
    }
    public void NextButton()  // Next Level
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReturnButton()  // Play this Level again
    {
        tryAgain = true;
        Time.timeScale = 1f;
        Timer.isFinnished = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    // Scene Play For Map Scene//
    public void PlayScene(string scene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }
}
