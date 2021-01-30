using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailGun : WeaponTool
{
    [SerializeField]
    GameObject nailPrefab = null;

    [SerializeField]
    Vector3 relativeNailStartCoords = new Vector3(0.29f, 1f, 1.04f);

    public override bool Use(RaycastHit hit)
    {
        if (equipped)
        {
            Instantiate(nailPrefab, gameObject.transform.position + relativeNailStartCoords, Quaternion.identity);
            gameObject.SetActive(false);
            return true;
        }
        return false;
    }

    public override void Equip()
    {
        GameObject rightHand = GameObject.FindGameObjectWithTag("RightHandPos");
        gameObject.transform.position = rightHand.transform.position;
        gameObject.transform.parent = rightHand.transform;
        gameObject.transform.LookAt(transform.parent.forward);
        base.Equip();
    }
}
