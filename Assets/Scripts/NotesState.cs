using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotesState : MonoBehaviour
{
    public GameObject[] callNotes;

    void Start()
    {
        StartCoroutine(SetActiveNote());
    }
    void Update()
    {

    }
    private IEnumerator SetActiveNote()
    {
        yield return new WaitForSeconds(1);
        callNotes[0].SetActive(true);
        callNotes[1].SetActive(true);
        callNotes[2].SetActive(true);
        callNotes[3].SetActive(true);
    }
    public void CloseNotes(int num)
    {
        callNotes[num].SetActive(false);
    }
}
