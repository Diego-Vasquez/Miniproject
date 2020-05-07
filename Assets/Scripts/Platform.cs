using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    GameObject Player;

    void Update()
    {
        if(Player != null)
        {
            Player.transform.up = transform.up;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player")) 
        {
            Player = col.gameObject;
            Player.GetComponent<Rigidbody>().velocity = new Vector3();
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Player = null;
        }
    }
}
