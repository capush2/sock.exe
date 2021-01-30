using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponTool
{
    Sprite Get2DSpriteTexture();
    void ToggleFlash();
    bool Use(RaycastHit hit);
    
}