using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apuntes : MonoBehaviour
{
    Rigidbody rbd;
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        // rbd = this.GetComponent<Rigidbody>()
        // rbd = GameObject.GetComponent<Rigidbody>()

        Input.GetKeyDown(KeyCode.Space);
        //Input.GetKeyDown("Space");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
