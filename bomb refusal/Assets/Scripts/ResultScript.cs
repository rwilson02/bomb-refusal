using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour
{
    public GameObject results;
    public Text message;
    public GameObject next, retry;
    public ChangeScene scene;
    public Patience pat;
    public AudioSource boomSFX;
    public GameObject explosion;
    public GameObject level;
    public PauseManager pause;
    public JukeScript music;
    public ShakeIt shk;

    readonly string[] msgs = { 
        "NICE ONE!", 
        "KABOOM!", 
        "YOU DID IT!", 
        "TWO THUMBS UP!", 
        "like and subscribe lol" 
    };

    public void EndLevel(bool success)
    {
        pat.Cease();
        if (pause.paused) { pause.paused = false; }
        pause.pausable = false;
        music.sauce.Stop();
        results.SetActive(true);
        if (success)
        {
            level.SetActive(false);
            Instantiate(explosion);
            boomSFX.PlayOneShot(boomSFX.clip, 0.5f);
            message.text = msgs[Random.Range(0, msgs.Length)];
            shk.Shake();
        }
        else
        {
            message.text = "DUD";
            next.SetActive(false);
            retry.SetActive(true);
        }
    }
}
