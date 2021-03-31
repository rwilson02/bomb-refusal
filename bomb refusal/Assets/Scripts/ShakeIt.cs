using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeIt : MonoBehaviour
{
    public float shakeDur;
    float interDur;
    public float shakeMag;
    Vector2 initPos;
    public RectTransform ShakeThis;

    private void Start()
    {
        interDur = shakeDur;
        initPos = ShakeThis.anchoredPosition;
        print(initPos);
    }

    // Update is called once per frame
    void Update()
    {
        if(shakeDur > 0)
        {
            ShakeThis.anchoredPosition = initPos + Random.insideUnitCircle * shakeMag * 
                Mathf.InverseLerp(0, interDur, shakeDur);
            shakeDur -= Time.deltaTime;
        }
        else
        {
            shakeDur = 0;
            ShakeThis.anchoredPosition = initPos;
        }
    }

    public void Shake()
    {
        shakeDur = 3;
    }
}
