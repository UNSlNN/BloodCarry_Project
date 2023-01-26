using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHandler : MonoBehaviour
{
    public GameObject[] stars;
    public GameObject[] passOrFail;
    [SerializeField] private int bloodCount; // number of available
    [SerializeField] private ItemState blood;
    public static bool haveStars;

    [SerializeField] int levelIndex;
    void Update()
    {
        CountItemIndex();
        if(HealthState.gameOver)
        {
            PlayerGameOver();
        }
        else
        {
            CountStars();
        }
        PressStars(bloodCount);
    }
    void CountItemIndex()
    {
        bloodCount = blood.itemBlood;
    }
    void CountStars()
    {
        // The quantity of blood when a player gets it

        if (bloodCount == 1)
        {
            // one star
            stars[0].SetActive(true);
            passOrFail[0].SetActive(true);
            passOrFail[1].SetActive(false);
            passOrFail[2].SetActive(true);
            passOrFail[3].SetActive(false);
            haveStars = true;
        }
        else if (bloodCount == 2)
        {
            // two star
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            passOrFail[0].SetActive(true);
            passOrFail[1].SetActive(false);
            passOrFail[2].SetActive(true);
            passOrFail[3].SetActive(false);
            haveStars = true;
        }
        else if (bloodCount == 3)
        {
            // three star
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            passOrFail[0].SetActive(true);
            passOrFail[1].SetActive(false);
            passOrFail[2].SetActive(true);
            passOrFail[3].SetActive(false);
            haveStars = true;
        }
        else if ((bloodCount == 0))
        {
            passOrFail[0].SetActive(false);
            passOrFail[1].SetActive(true);
            passOrFail[2].SetActive(false);
            passOrFail[3].SetActive(true);
            haveStars = false;
        }
    }
    void PlayerGameOver()
    {
        stars[0].SetActive(false);
        stars[1].SetActive(false);
        stars[2].SetActive(false);
        passOrFail[0].SetActive(false);
        passOrFail[1].SetActive(true);
        passOrFail[2].SetActive(false);
        passOrFail[3].SetActive(true);
    }
    public void PressStars(int starsNum)
    {
        if(bloodCount > PlayerPrefs.GetInt("LV" + levelIndex))
        {
            if (UIState.iswinner)
            {
                PlayerPrefs.SetInt("LV" + levelIndex, starsNum);
            }
        }
        //Debug.Log(PlayerPrefs.GetInt("LV" + levelIndex, starsNum));
    }
}
