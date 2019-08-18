using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Timer : MonoBehaviour
{
    public Text text;

    private TimerSequence timerSequence;
    private float timeCont = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        timerSequence = TimerSequence.START;
        text.text = "00.0";
    }

    // Update is called once per frame
    void Update()
    {
        if (timerSequence == TimerSequence.START)
        {
            timeCont += Time.deltaTime;
        }
        text.text = String.Format("{0:000.0}", timeCont);
    }

    public void Stop()
    {
        timerSequence = TimerSequence.STOP;
        text.color = Color.red;
    }
    private enum TimerSequence
    {
        STOP,
        START
    }
}
