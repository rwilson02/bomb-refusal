using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTurner : MonoBehaviour
{
    Camera cam;
    public AudioClip aud;
    AudioSource sus;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        sus = cam.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Clicked() > -1)
        {
            int dir = Clicked();
            RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector3.zero);

            if(hit.collider != null && hit.collider.CompareTag("Tile"))
            {
                Transform tile = hit.transform;
                var eul = tile.eulerAngles;

                if (dir == 0)
                {
                    eul.z += 90;
                }
                else
                {
                    eul.z -= 90;
                }

                tile.eulerAngles = eul;
                sus.PlayOneShot(aud);
            }
        }
    }

    private int Clicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return 0;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            return 1;
        }
        else return -1;
    }
}
