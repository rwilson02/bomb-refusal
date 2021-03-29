using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterScript : MonoBehaviour
{
    public List<FuseScript> fuses;
    public Sprite[] img = new Sprite[2];
    bool burnt = false, keepChecking = true;
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        foreach(Transform fuse in transform)
        {
            fuses.Add(fuse.GetComponent<FuseScript>());
        }
    }

    private void Update()
    {
        if (keepChecking)
        {
            if (!burnt)
            {
                sprite.sprite = img[0];
                CheckForBurning();
            }
            else
            {
                sprite.sprite = img[1];
                foreach(FuseScript fs in fuses)
                {
                    fs.StartBurning(false);
                }
                keepChecking = false;
            }
        }
    }

    private void CheckForBurning()
    {
        foreach(FuseScript fs in fuses)
        {
            if (fs.burnt == true)
            {
                burnt = true;
            }
        }
    }
}
