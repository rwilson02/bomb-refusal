using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public KeyCode pause;
    public bool paused = false;
    public bool pausable = false;
    public AudioSource burn;
    public GameObject pauseScreen;
    public JukeScript music;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pause) && pausable)
        {
            if (paused)
            {
                Time.timeScale = 1;
                pauseScreen.SetActive(false);
                music.sauce.UnPause();
                burn.UnPause();
            }
            else
            {
                music.sauce.Pause();
                burn.Pause();
                pauseScreen.SetActive(true);
                Time.timeScale = 0;
            }

            paused = !paused;
        }
    }
}
