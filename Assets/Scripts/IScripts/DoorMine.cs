using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMine : WeaponTool
{
    public override void Use(RaycastHit hit)
    {
        if (isEquipped && hit.transform.tag == "Door")
        {
            this.transform.parent = hit.transform;
        }
    }

}
