using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementObject : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 TorqueObject = new Vector3 (0,0,0);

    void Start(){
        rb = GetComponent<Rigidbody>();

    }

    void Update(){
        rb.AddTorque(TorqueObject, ForceMode.Impulse);
        print(rb.angularVelocity);
    }
}
