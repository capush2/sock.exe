using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailVelocity : MonoBehaviour
{
    [SerializeField]
    float impulseForce = 150;
    void Awake()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward*impulseForce*Time.deltaTime, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        var v = transform.position + GetComponent<Rigidbody>().velocity;
        transform.LookAt(v);
        Debug.Log(v);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (transform.position + GetComponent<Rigidbody>().velocity) * 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }
}
