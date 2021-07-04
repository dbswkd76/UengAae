using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameObject[] timers;
    void Start()
    {
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        Time.timeScale = 0f;
        yield return StartCoroutine(ChangeUi());
        Time.timeScale = 1f;
    }

    IEnumerator ChangeUi()
    {
        for (int i = 0; i < 3; i++)
        {
            timers[i].SetActive(true);
            yield return new WaitForSecondsRealtime(0.5f);
            timers[i].SetActive(false);
        }

    }
}