using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailGun : MonoBehaviour, IWeaponTool
{
    [SerializeField]
    GameObject nailPrefab = null;

    [SerializeField]
    Vector3 relativeNailStartCoords = new Vector3(0.29f, 1f, 1.04f);

    [SerializeField]
    private bool isEquiped;

    private Outline[] childrenOutlines;

    void Awake()
    {
        isEquiped = false;
        childrenOutlines = GetComponentsInChildren<Outline>();
    }

    void Start()
    {
        foreach (var o in childrenOutlines)
        {
            o.enabled = false;
        }
    }
    public void Equip()
    {
        isEquiped = true;
    }

    public void UnEquip()
    {
        isEquiped = false;
    }

    public void Use()
    {
        if (isEquiped)
        {
            Instantiate(nailPrefab, relativeNailStartCoords, Quaternion.identity, transform);
            gameObject.SetActive(false);
            isEquiped = false;
        }
    }

    public void ToggleFlash()
    {
        foreach(var o in childrenOutlines)
        {
            o.enabled = !o.enabled;
        }
    }
}
