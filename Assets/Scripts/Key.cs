using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject Object;
    public float AngVel;
    private void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, AngVel);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Object.SetActive(true);
            Destroy(gameObject);
        }
    }
}
