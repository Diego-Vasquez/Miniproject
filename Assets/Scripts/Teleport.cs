using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject Pos;
    public float AngVel;
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = new Vector3 (0, AngVel);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = Pos.transform.position;
            other.gameObject.transform.up = Pos.transform.up;
            Destroy(gameObject);
        }
    }
}
