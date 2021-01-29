﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponTool
{
    void Equip();
    void UnEquip();
    void Use();
    void ToggleFlash();
}