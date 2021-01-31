using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailGun : WeaponTool
{
    [SerializeField]
    GameObject nailPrefab = null;

    public override bool Use(RaycastHit hit)
    {
        if (equipped)
        {
            Ray ray = gameObject.transform.parent.transform.parent.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            GameObject current = Instantiate(nailPrefab);
            current.transform.position = gameObject.transform.position;
            if (Physics.Raycast(ray, out hit))
            {
                current.transform.LookAt(hit.point);
            } else
            {
                current.transform.rotation = gameObject.transform.rotation;
            }
            gameObject.SetActive(false);
            return true;
        }
        return false;
    }

    public override void Equip()
    {
        base.Equip();
        transform.rotation = gameObject.transform.parent.transform.parent.rotation;
    }
}
