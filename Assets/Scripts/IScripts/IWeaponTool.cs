using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponTool
{
    Sprite Get2DSpriteTexture();
    void Equip();
    void ToggleFlash();
    void UnEquip();
    void Use(RaycastHit hit);
    
}