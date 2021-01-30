using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMine : WeaponTool
{
    public override bool Use(RaycastHit hit)
    {
        if (hit.transform.tag == "Door")
        {
            this.transform.parent = hit.transform;
        }
        return true;
    }

}
