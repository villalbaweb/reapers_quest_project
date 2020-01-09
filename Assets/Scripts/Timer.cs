using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public delegate void FinishEvent();
    public event FinishEvent OnFinished;

    public delegate void TickEvent();
    public event TickEvent OnTick;

    // Config Props
    [SerializeField] float totalTime = 30f;
    [SerializeField] float tickTime = 5f;
    [SerializeField] bool cycle = false;

    // state
    float timeLeft;
    float tickTimer;
    bool isTimerFinished;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = totalTime;
        tickTimer = 0f;
        isTimerFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerFinished && !cycle) { return; }

        timeLeft -= Time.deltaTime;
        if(timeLeft < 0)
        {
            if(OnFinished != null) OnFinished();
            isTimerFinished = true;
            timeLeft = totalTime;
        }

        tickTimer += Time.deltaTime;
        if(tickTimer >= tickTime)
        {
            if (OnTick != null) OnTick();
            tickTimer = 0f;
        }
    }

    public float GetTimeLeft()
    {
        return timeLeft;
    }

    public float GetTotalTime()
    {
        return totalTime;
    }
}
