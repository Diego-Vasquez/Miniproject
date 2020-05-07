using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOfCharacter : MonoBehaviour
{
    public GameObject Sphere, Cube;
    public PhysicMaterial NoMove, WallAndPlane;
    Rigidbody rbd;
    Transform trans;
    Vector3 lposition;
    Quaternion lrotation;
    bool change;
    private void Start()
    {
        trans = GetComponent<Transform>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            change = !change;
            lposition = trans.localPosition;
            lrotation = trans.localRotation;
            Debug.Log(lposition);

            if (change)
            {
                trans.SetParent(Cube.transform);
                trans.localPosition = lposition;
                trans.localRotation = lrotation;
                Sphere.GetComponent<SphereCollider>().material = NoMove;
                Cube.GetComponent<BoxCollider>().material = WallAndPlane;
                Sphere.GetComponent<MoveGetAxes>().enabled = false;
                Cube.GetComponent<MoveGetAxes>().enabled = true;
            }
            else
            {
                trans.SetParent(Sphere.transform);
                trans.localPosition = lposition;
                trans.localRotation = lrotation;
                Sphere.GetComponent<SphereCollider>().material = WallAndPlane;
                Cube.GetComponent<BoxCollider>().material = NoMove;
                Sphere.GetComponent<MoveGetAxes>().enabled = true;
                Cube.GetComponent<MoveGetAxes>().enabled = false;
            }
        }
    }
}
