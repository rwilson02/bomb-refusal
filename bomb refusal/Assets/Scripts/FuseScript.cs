using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseScript : MonoBehaviour
{
    public Animator burnings;
    //public KeyCode DebugIN;
    FuseScript connection;

    public GameObject connector;
    ConnectorScript connectorScript;

    public CenterScript center;

    public bool burnt = false;
    public bool started = false;

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
        CheckConnect();

        //debug commands
        //{
        //    if (Input.GetKeyDown(DebugIN))
        //    {
        //        if (burnings != null)
        //        {
        //            burnings.ResetTrigger("burnIn");
        //            burnings.ResetTrigger("burnOut");
        //        }
        //        StartBurning(true);
        //    }
        //}
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

    public void PassItOn()
    {
        if (connection != null)
        {
            connection.StartBurning(true);
        }
    }

    public void Burnt()
    {
        burnt = true;
    }
}
