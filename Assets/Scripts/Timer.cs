using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text time;
    private float startTime;
    public static bool isFinnished = false;
    void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        if (isFinnished)
            return;
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");
        time.text = minutes + ":" + seconds;
    }
    //  Timer.isFinnished = true;
    // if play new game(tryAgain). Reset time count, And start new time
}
