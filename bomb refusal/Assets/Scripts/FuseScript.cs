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

    public Patience pat;

    public bool burnt = false;
    public bool started = false;
    public bool endOfLVL = false;

    // Start is called before the first frame update
    void Start()
    {
        burnings = gameObject.GetComponent<Animator>();
        connectorScript = connector.GetComponent<ConnectorScript>();
        pat = Camera.main.GetComponent<Patience>();

        if (!endOfLVL) connector = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        CheckConnect();
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
            if (connection.endOfLVL)
            {
                connection.SendMessage("EndLevel", true);
            }
            else 
            { 
                connection.StartBurning(true);
                pat.CalmDown();
            }
        }
    }

    public void Burnt()
    {
        burnt = true;
    }
}
