using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float gravity = -12;
    public void Attract(Transform playerTrans)
    {
        Vector3 gravityUp = (playerTrans.position - transform.position).normalized;
        Vector3 localUp = playerTrans.up;

        playerTrans.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);  //make the body head towards planet

        Quaternion target = Quaternion.FromToRotation(localUp, gravityUp) * playerTrans.rotation;
        playerTrans.rotation = Quaternion.Slerp(playerTrans.rotation, target, 50f * Time.deltaTime);
 
    }
}
