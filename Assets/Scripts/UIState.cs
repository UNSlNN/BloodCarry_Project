using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIState : MonoBehaviour
{
    // when player touching this collider, Come to next level
    [SerializeField] private GameObject boardUI;
    [SerializeField] private GameObject pushUI;
    [SerializeField] private GameObject settindUI;
    public static bool iswinner;
    public static bool GameIsPaused;
    void Start()
    {
        boardUI.SetActive(false);
        pushUI.SetActive(false);
        settindUI.SetActive(false);
        iswinner = false;
        GameIsPaused = false;
    }
    void Update()
    {
        if (HealthState.gameOver) // If Player Gameover
        {
            StartCoroutine(UIDelay());
        }
        UpdatePause();
    }
    private void OnTriggerEnter2D(Collider2D collLevel) // check to go next scene
    {
        // Pass Level
        if (collLevel.gameObject.tag == "Level")
        {
            boardUI.SetActive(true);
            Timer.isFinnished = true;
            iswinner = true;
            if (StarHandler.haveStars == true)
            {
                FindObjectOfType<AudioManager>().PlaySound("Win");
                Debug.Log("Win");
            }
            else
            {
                ScenePlay.tryAgain = true;
                FindObjectOfType<AudioManager>().PlaySound("Lose");
                Debug.Log("Lose");
            }
        }
    }
    IEnumerator UIDelay()
    {
        yield return new WaitForSeconds(1.6f);
        boardUI.SetActive(true);
    }
    // Open UI 
    public void OpenSetting()  // Setting Menu
    {
        if(iswinner)
        {
            boardUI.SetActive(false);
        }
        settindUI.SetActive(true);
    }
    public void CloseSetting()  // Setting Menu
    {
        if (iswinner)
        {
            boardUI.SetActive(true);
        }
        settindUI.SetActive(false);
    }
    // Pause State
    void UpdatePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pushUI.SetActive(false);
        settindUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pushUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    // FullScreen set
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}
