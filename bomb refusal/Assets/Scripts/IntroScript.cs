using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    public Timer timer;

    public void StartLevel()
    {
        timer.timed = true;
        gameObject.SetActive(false);
    }
}
