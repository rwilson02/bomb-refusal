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

    readonly string[] msgs = { "NICE ONE!", "KABOOM!", "YOU DID IT!", "TWO THUMBS UP!" };

    public void EndLevel(bool success)
    {
        pat.Cease();
        results.SetActive(true);
        if (success)
        {
            level.SetActive(false);
            Instantiate(explosion);
            boomSFX.PlayOneShot(boomSFX.clip);
            message.text = msgs[Random.Range(0, msgs.Length)];
        }
        else
        {
            message.text = "DUD";
            next.SetActive(false);
            retry.SetActive(true);
        }
    }
}
