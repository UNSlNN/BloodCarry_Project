using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private bool unlocked;
    public Image unlockImage;
    public GameObject[] stars;
    public Sprite starsSprite;
    void Start()
    {

    }
    void Update()
    {
        UpdateLevelImage();
        UpdateLevelStatus();
    }
    private void UpdateLevelStatus()
    {
        int preiousLevelNum = int.Parse(gameObject.name) - 1;
        if (PlayerPrefs.GetInt("LV" + preiousLevelNum.ToString()) > 0)
        {
            unlocked = true;
        }
    }
    private void UpdateLevelImage()
    {
        if(!unlocked)
        {
            unlockImage.gameObject.SetActive(true);
            for(int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(false);
            }
        }
        else
        {
            unlockImage.gameObject.SetActive(false);
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(true);
            }
            for(int i = 0; i < PlayerPrefs.GetInt("LV" + gameObject.name); i++)
            {
                stars[i].gameObject.GetComponent<Image>().sprite = starsSprite;
            }
        }
    }
    public void PressSelection(string Level)
    {
        if(unlocked)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(Level);
        }
    }

}
