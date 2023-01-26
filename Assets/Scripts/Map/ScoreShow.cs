using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreShow : MonoBehaviour
{
    public Text starsText;
    void Update()
    {
        UpdateStarsUI();
    }
    private void UpdateStarsUI()
    {
        int sum = 0;
        for(int i = 0; i < 5; i++)
        {
            sum += PlayerPrefs.GetInt("LV" + i.ToString()); // collect stars by Levels
        }
        starsText.text = sum + "/" + 12;
    }
}
