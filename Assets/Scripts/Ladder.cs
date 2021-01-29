using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    GameObject playerOBJ;
    bool canClimb = false;
    float speed = 10;

    void OnTriggerEnter(Collider coll)
    {
        Debug.Log("Enter");
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("Player");
            canClimb = true;
            playerOBJ = coll.gameObject;
        }
    }

    void OnTriggerExit(Collider coll2)
    {
        Debug.Log("Leave");
        if (coll2.gameObject.tag == "Player")
        {
            canClimb = false;
            playerOBJ = null;
        }
    }
    void Update()
    {
        if (canClimb)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                playerOBJ.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                playerOBJ.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
            }
        }
    }
}
