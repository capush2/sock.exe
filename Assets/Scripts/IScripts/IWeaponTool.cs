using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponTool
{
    void Equip();
    Sprite Get2DSpriteTexture();
    void ToggleFlash();
    void UnEquip();
    bool Use(RaycastHit hit);
    
}