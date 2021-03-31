using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patience : MonoBehaviour
{
    public Timer timer;
    public ResultScript res;
    public AudioSource burn;
    public float margin = 3;
    public float patience;

    bool anger = false;

    private void Start()
    {
        patience = timer.TimeToComplete + margin;
    }

    void Update()
    {
        if (timer.timed)
        {
            if (!anger)
            {
                burn.Play();
            }
            anger = true;
        }

        if (anger)
        {
            if (timer.timed)
            {
                patience = timer.timeLeft + margin;
            }
            else patience -= Time.deltaTime;
        }

        if(patience < 0)
        {
            res.EndLevel(false);
            patience = 420;
            burn.Stop();
        }
    }

    public void CalmDown()
    {
        patience = margin;
    }

    public void Cease()
    {
        anger = false;
        burn.Stop();
    }
}
