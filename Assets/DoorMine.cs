using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMine : MonoBehaviour, IWeaponTool
{

    [SerializeField]
    private bool isEquipped;

    private Outline[] childrenOutlines;

    void Awake()
    {
        isEquipped = false;
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
        isEquipped = true;
    }

    public void ToggleFlash()
    {
        foreach (var o in childrenOutlines)
        {
            o.enabled = !o.enabled;
        }
    }

    public void UnEquip()
    {
        isEquipped = false;
    }

    public void Use(RaycastHit hit)
    {
        if (isEquipped && hit.transform.tag == "Door")
        {
            this.transform.parent = hit.transform;
        }
    }

}
