using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorScript : MonoBehaviour
{
    public GameObject connected;

    private void OnTriggerExit2D(Collider2D collision)
    {
        connected = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        connected = collision.gameObject;
    }
}
