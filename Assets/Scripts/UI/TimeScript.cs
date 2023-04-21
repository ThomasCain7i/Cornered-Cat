using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TimeScript : MonoBehaviour
{
    bool stopWatchActive = false;
    public float TimeCounter;
    public int startMinutes;
    public TMP_Text currentTimeText;

    void Start()
    {
        TimeCounter = 0;
        StartStopwatch();
    }

    void Update()
    {
        if(stopWatchActive == true)
        {
            TimeCounter = TimeCounter + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(TimeCounter);
        currentTimeText.text = time.ToString(@"mm\:ss\:fff");
    }

    public void StartStopwatch()
    {
        stopWatchActive = true;
    }

    public void StopStopwatch()
    {
        stopWatchActive = false;
    }
}
