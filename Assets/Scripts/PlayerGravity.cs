using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    public Planet attractor;
    private Transform playerTrans;
    void Start()
    {
        //GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<Rigidbody>().useGravity = false;
        playerTrans = transform;
    }

    private void Update()
    {
        attractor.Attract(playerTrans);
    }
    //void FixedUpdate()
    //{
    //    if (attractor)
    //    {
    //        attractor.Attract(playerTrans);
    //    }

    //}
}
