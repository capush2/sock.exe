using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : WeaponTool
{
    AudioSource source;
    private bool opened = false;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public override bool Use(RaycastHit hit)
    {
        if (hit.collider.gameObject.tag == "Floor")
        {
            transform.position = hit.point;
            GameObject container = new GameObject();
            container.transform.parent = hit.collider.transform;
            transform.parent = container.transform;
            transform.eulerAngles = hit.normal.normalized * 90;

            opened = true;
            Used = true;
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (opened && other.gameObject.layer == LayerMask.NameToLayer("Living"))
        {
            AudioSource.PlayClipAtPoint(source.clip, source.transform.position);
            transform.GetChild(3).eulerAngles += new Vector3(85, 0, 0);
            transform.GetChild(4).eulerAngles += new Vector3(85, 0, 0);
            opened = false;
            other.gameObject.GetComponent<LivingThing>().OnBearTrapHit();
        }
    }

}
