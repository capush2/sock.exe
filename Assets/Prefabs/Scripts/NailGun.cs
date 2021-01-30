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

    public override void Use(RaycastHit hit)
    {
        if (isEquipped)
        {
            Instantiate(nailPrefab, relativeNailStartCoords, Quaternion.identity, transform);
            gameObject.SetActive(false);
            isEquipped = false;
        }
    }
}
