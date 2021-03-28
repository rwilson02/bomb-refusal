using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseScript : MonoBehaviour
{
    public Animator burnings;
    public KeyCode DebugIN, DebugOUT;
    GameObject connection;

    public GameObject connector;
    ConnectorScript connectorScript;

    // Start is called before the first frame update
    void Start()
    {
        burnings = gameObject.GetComponent<Animator>();
        connector = gameObject.transform.GetChild(0).gameObject;
        connectorScript = connector.GetComponent<ConnectorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(connection != null)
        {
            CheckConnect();
        }

        //debug commands
        {
            if (Input.GetKeyDown(DebugIN))
            {
                if (burnings != null)
                {
                    burnings.ResetTrigger("burnIn");
                    burnings.ResetTrigger("burnOut");
                }
                StartBurning(true);
            }

            if (Input.GetKeyDown(DebugOUT))
            {
                if (burnings != null)
                {
                    burnings.ResetTrigger("burnIn");
                    burnings.ResetTrigger("burnOut");
                }
                StartBurning(false);
            }
        }
    }

    public void StartBurning(bool inward)
    {
        if (burnings != null)
        {
            if (inward)
            {
                burnings.SetTrigger("burnIn");
            }
            else
            {
                burnings.SetTrigger("burnOut");
            }
        }
    }

    public void CheckConnect()
    {
        connection = connectorScript.connected;
    }
}
