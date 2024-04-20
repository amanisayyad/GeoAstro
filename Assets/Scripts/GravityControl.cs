using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControl : MonoBehaviour
{
    //public GravityOrbit Gravity;
    //private Rigidbody rb;

    //public float RotationSpeed = 20;

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}

    //void FixedUpdate()
    //{
    //    if (Gravity)
    //    {
    //        Vector3 gravityUp = Vector3.zero;
    //        gravityUp = (transform.position - Gravity.transform.position).normalized;

    //        Vector3 localUp = transform.up;

    //        Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * transform.rotation;

    //        transform.up = Vector3.Lerp(transform.up, gravityUp, RotationSpeed * Time.deltaTime);
    //        rb.AddForce(-gravityUp * Gravity.Gravity * rb.mass);
    //    }
    //}
}
