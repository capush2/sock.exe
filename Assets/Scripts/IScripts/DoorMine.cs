using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMine : WeaponTool
{
    public override bool Use(RaycastHit hit)
    {
        if (hit.transform != null && hit.transform.tag == "Door")
        {
            transform.parent = hit.transform;
            gameObject.SetActive(true);
            return true;
        }
        return false;
    }

}
