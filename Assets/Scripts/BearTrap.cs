using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : WeaponTool
{
    private bool opened = true;

    public override bool Use(RaycastHit hit)
    {
        throw new System.NotImplementedException();
    }

    //private IEnumerator OnTriggerEnter(Collider other)
    //{
    //    if (opened)
    //    {
    //        transform.GetChild(3).eulerAngles += new Vector3(85, 0, 0);
    //        transform.GetChild(4).eulerAngles += new Vector3(85, 0, 0);
    //        opened = false;
    //        other.gameObject.GetComponent<BearTrapTest>().Stop();
    //        yield return new WaitForSecondsRealtime(5);
    //        other.gameObject.GetComponent<BearTrapTest>().BreakFree();
    //    }
    //}

}
