using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailVelocity : MonoBehaviour
{
    [SerializeField]
    float impulseForce = 150;
    void Start()
    {
        
        GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward)*impulseForce*Time.deltaTime, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        var v = transform.position + GetComponent<Rigidbody>().velocity;
        transform.LookAt(v);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (transform.position + GetComponent<Rigidbody>().velocity) * 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player")
            GetComponent<Rigidbody>().isKinematic = true;
    }
}
