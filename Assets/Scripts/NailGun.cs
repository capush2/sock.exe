using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailGun : MonoBehaviour, IWeaponTool
{
    [SerializeField]
    GameObject nailPrefab = null;

    [SerializeField]
    Sprite Texture2D;

    [SerializeField]
    Vector3 relativeNailStartCoords = new Vector3(0.29f, 1f, 1.04f);

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
    public Sprite Get2DSpriteTexture()
    {
        return Texture2D;
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
        if (isEquipped)
        {
            Instantiate(nailPrefab, relativeNailStartCoords, Quaternion.identity, transform);
            gameObject.SetActive(false);
            isEquipped = false;
        }
    }
}
