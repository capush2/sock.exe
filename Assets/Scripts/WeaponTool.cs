using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class WeaponTool : MonoBehaviour, IWeaponTool
{
    [SerializeField]
    protected Sprite Texture2D;

    [SerializeField]
    protected bool isEquipped;

    protected Outline[] childrenOutlines;

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

    public Sprite Get2DSpriteTexture()
    {
        return Texture2D;
    }

    public virtual void Equip()
    {
        isEquipped = true;
    }

    public virtual void ToggleFlash()
    {
        foreach (var o in childrenOutlines)
        {
            o.enabled = !o.enabled;
        }
    }

    public virtual void UnEquip()
    {
        isEquipped = false;
    }

    abstract public void Use(RaycastHit hit);
}
