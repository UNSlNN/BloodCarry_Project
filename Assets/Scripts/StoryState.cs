using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryState : MonoBehaviour
{
    [Header("PopUp")]
    [SerializeField] GameObject callStoryLine;
    [SerializeField]
    GameObject[] aa;
    [Header("Sound Settings")]
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.8f;

    void Start()
    {
        StartCoroutine(StoryLine());
    }

    void Update()
    {

    }
    public void CloseStoryLine(GameObject story)        // close pop up after click
    {
        Destroy(story, 0.5f);

    }
    private IEnumerator StoryLine()         // count time before active story
    {    
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(clip, volume);
        callStoryLine.SetActive(true);
    }
}
