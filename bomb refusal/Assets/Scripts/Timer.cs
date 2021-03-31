using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float TimeToComplete;
    public float timeLeft;
    public bool timed = false;
    Image timer;
    public FuseScript innie;
    public GameObject burnFX;
    public KeyCode speedUp;
    GameObject theBurn;
    Camera cam;
    float g;
    int mult = 1;

    private void Start()
    {
        timer = gameObject.GetComponent<Image>();
        timeLeft = TimeToComplete;
        theBurn = Instantiate(burnFX);
        theBurn.transform.position = new Vector3(-10, 3.15f, 0);
        cam = Camera.main;
        g = timer.GetComponent<RectTransform>().rect.height / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (timed)
        {
            timeLeft -= Time.deltaTime * mult;
            timer.fillAmount = Mathf.InverseLerp(0, TimeToComplete, timeLeft);

            theBurn.transform.position = cam.ScreenToWorldPoint(new Vector3(
                Mathf.Lerp(cam.pixelWidth, 0, timer.fillAmount),
                cam.pixelHeight - g,
                10
                ));

            if (timeLeft < 0)
            {
                Destroy(theBurn);
                timed = false;
                innie.StartBurning(true);
            }
        }

        if (Input.GetKeyDown(speedUp) || Input.GetMouseButtonDown(2))
        {
            mult++;
        }
    }
}
