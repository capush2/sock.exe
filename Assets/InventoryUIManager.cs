using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject[] inventoryDisplay = new GameObject[3];
    public Image[] inventorySprites = new Image[3];

    public void AddToInventory(GameObject weaponTool)
    {
        bool found = false;
        for(int i = 0; i < inventoryDisplay.Length; i++)
        {
            if(inventoryDisplay[i] == null)
            {
                found = true;
                inventoryDisplay[i] = weaponTool;
                inventorySprites[i].sprite = weaponTool.GetComponent<IWeaponTool>().Get2DSpriteTexture();
                break;
            }
        }
        if (!found)
        {
            inventoryDisplay[0] = weaponTool;
            inventorySprites[0].sprite = weaponTool.GetComponent<IWeaponTool>().Get2DSpriteTexture();
        }
        
    }
}
