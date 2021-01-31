using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class WeaponTool : MonoBehaviour, IWeaponTool
{
    [SerializeField]
    protected Sprite Texture2D;
    protected bool equipped;
    public bool Used { get; protected set; }

    protected Outline[] childrenOutlines;

    void Awake()
    {
        childrenOutlines = GetComponentsInChildren<Outline>();
    }
    public virtual void Equip()
    {
        GameObject rightHand = GameObject.FindGameObjectWithTag("RightHandPos");
        gameObject.transform.position = rightHand.transform.position;
        gameObject.transform.parent = rightHand.transform;
        gameObject.SetActive(true);
        equipped = true;
    }

    public Sprite Get2DSpriteTexture()
    {
        return Texture2D;
    }

    void Start()
    {
        foreach (var o in childrenOutlines)
        {
            o.enabled = false;
        }
    }

    public virtual void ToggleFlash()
    {
        
        foreach (var o in childrenOutlines)
        {
            if (Used)
            {
                o.enabled = false;
            } else
            {
                o.enabled = !o.enabled;
            }
        }
    }

    public virtual void UnEquip()
    {
        gameObject.SetActive(false);
        equipped = false;
    }

    abstract public bool Use(RaycastHit hit);
}
