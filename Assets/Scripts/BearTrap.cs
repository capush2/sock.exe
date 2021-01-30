using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : WeaponTool
{
    private bool opened = true;

    public override bool Use(RaycastHit hit)
    {
        if (hit.collider.gameObject.tag == "Floor")
        {
            transform.position = hit.point;
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (opened && other.gameObject.layer == LayerMask.NameToLayer("Living"))
        {
            transform.GetChild(3).eulerAngles += new Vector3(85, 0, 0);
            transform.GetChild(4).eulerAngles += new Vector3(85, 0, 0);
            opened = false;

            if (other.gameObject.tag == "Player")
            {
                
            } else if (other.gameObject.tag == "AI")
            {

            }
        }
    }

}
