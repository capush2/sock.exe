using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailVelocity : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward*15, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
