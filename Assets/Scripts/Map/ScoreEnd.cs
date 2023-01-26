using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEnd : MonoBehaviour
{
    public GameObject board;
    public GameObject head;
    public GameObject score;
    public GameObject homeUI;
    void Start()
    {
        board.SetActive(false);
        head.SetActive(false);
        score.SetActive(false);
        homeUI.SetActive(false);
    }
    public void ShowScore()
    {
        board.SetActive(true);
        StartCoroutine(HeadShowable());
        StartCoroutine(ScoreShowable());
        StartCoroutine(HomeUIShowable());
    }
    private IEnumerator HeadShowable()
    {
        yield return new WaitForSeconds(1.5f);
        head.SetActive(true);
    }
    private IEnumerator ScoreShowable()
    {
        yield return new WaitForSeconds(4);
        score.SetActive(true);
        FindObjectOfType<AudioManager>().PlaySound("Win");
    }
    private IEnumerator HomeUIShowable()
    {
        yield return new WaitForSeconds(5.5f);
        homeUI.SetActive(true);
    }


}
