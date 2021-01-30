using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class WeaponTool : MonoBehaviour, IWeaponTool
{
    [SerializeField]
    protected Sprite Texture2D;

    protected Outline[] childrenOutlines;

    void Awake()
    {
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

    public virtual void ToggleFlash()
    {
        foreach (var o in childrenOutlines)
        {
            o.enabled = !o.enabled;
        }
    }

    abstract public bool Use(RaycastHit hit);
}
