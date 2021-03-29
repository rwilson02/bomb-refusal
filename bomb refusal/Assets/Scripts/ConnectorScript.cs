using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorScript : MonoBehaviour
{
    public FuseScript connected;
    Collider2D connector;
    Collider2D[] knex = new Collider2D[1];
    ContactFilter2D cf;

    private void Start()
    {
        connector = GetComponent<Collider2D>();
        cf.useTriggers = true;
        cf.SetDepth(-0.65f, -0.55f);
    }

    private void Update()
    {
        if (connector.OverlapCollider(cf, knex) > 0)
        {
            connected = knex[0].transform.parent.gameObject.GetComponent<FuseScript>();
        } 
        else
        {
            connected = null;
        }
    }
}
