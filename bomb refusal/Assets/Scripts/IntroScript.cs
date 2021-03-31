using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    public Timer timer;
    public PauseManager pause;
    public JukeScript music;

    public void StartLevel()
    {
        timer.timed = true;
        music.Jam();
        pause.pausable = true;
        gameObject.SetActive(false);
    }
}
