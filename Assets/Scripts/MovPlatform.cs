using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlatform : MonoBehaviour
{
    public Transform PSup, PInf;
    public float MoveVel;
    Transform trans;
    bool Move;
    private void Start()
    {
        trans = transform;
    }

    void Update()
    {
        if (trans.position == PSup.position) Move = true;
        else if (trans.position == PInf.position) Move = false;
    }

    void FixedUpdate()
    {
        if (Move) transform.position = Vector3.MoveTowards(trans.position, PInf.position, MoveVel*Time.fixedDeltaTime);
        else transform.position = Vector3.MoveTowards(trans.position, PSup.position, MoveVel * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision col)
    {
        col.gameObject.transform.parent = trans;
    }

    void OnCollisionExit(Collision col)
    {
        col.gameObject.transform.parent = null;
    }
}
