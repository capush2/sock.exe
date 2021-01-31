using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    AudioSource source;
    bool isInCollision = false, wasCollided = false;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isInCollision = (GetComponent<Rigidbody>().velocity != Vector3.zero);
        if (wasCollided && !isInCollision)
        {
            AudioSource.PlayClipAtPoint(source.clip, source.transform.position);
        }
        wasCollided = isInCollision;
    }
}
