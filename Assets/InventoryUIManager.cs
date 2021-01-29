using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    void Start()
    {
        
    }
    public GameObject[] inventoryDisplay = new GameObject[3];
    public Sprite[] inventorySprites = new Sprite[3];
    public void AddToInventory(GameObject weaponTool)
    {
        inventoryDisplay[0] = weaponTool;
        //invetorweaponTool.GetComponent<IWeaponTool>().Get2DSpriteTexture();
    }
}
