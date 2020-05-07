using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using System;

public class MoveGetAxes : MonoBehaviour
{
    Rigidbody rbd;
    Transform trans;
    public Vector3 Velocity;
    public float MaxVel, ForceJump, MaxNumJump, Sensibility;
    public int num_jump;
    float vx, vz, camerax, angule;
    bool jump, paso;
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();
    }
    void Update()
    {
        //Bools of Jump 
        if (paso) num_jump = 0;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (num_jump < MaxNumJump)
            {
                jump = true;
                num_jump++;
            }
            else jump = false;
        }
        else jump = false;
        
        //Bools of move on the plane XZ
        vx = Input.GetAxis("Horizontal") * MaxVel;
        vz = Input.GetAxis("Vertical") * MaxVel;
        camerax = Input.GetAxis("Mouse X")*Sensibility;
        angule = trans.rotation.eulerAngles.y*Mathf.PI/180;
    }
    void FixedUpdate()
    {

        if (jump)
        {
            trans.position += new Vector3(0, 0.2f) ;
            rbd.velocity = new Vector3(rbd.velocity.x, 0, rbd.velocity.z);
            rbd.AddForce(0, ForceJump, 0, ForceMode.Impulse);
        }
        rbd.velocity= new Vector3(vx* (float)Math.Cos(angule) + vz*(float)Math.Sin(angule), rbd.velocity.y, -vx*(float)Math.Sin(angule) +vz* (float)Math.Cos(angule));
        rbd.angularVelocity = new Vector3(0, camerax);
        Velocity = rbd.velocity;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("JumpZone")) paso = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("JumpZone")) paso = false;
    }

    private void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.CompareTag("JumpZone")) paso = true;
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("JumpZone")) paso = false;
    }
}
