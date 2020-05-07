using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Information Information;
    Rigidbody rbd;
    public float AngularVel;
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        Information = FindObjectOfType<Information>();

        rbd.angularVelocity = new Vector3(0, AngularVel);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Information.Coins++;
            Destroy(gameObject);
        }
    }
}
