using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject[] inventoryDisplay = new GameObject[3];
    public Image[] inventorySprites = new Image[3];
    [SerializeField] private Sprite emptyInventorySlot;
    private GameObject equipped;
    private int numEquipped = -1;
    public bool hasEquipped
    {
        get
        {
            return numEquipped != -1;
        }
    }

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
                Debug.Log($"Added {weaponTool.name} to inventory");
                break;
            }
        }
        if (!found)
        {
            inventoryDisplay[0] = weaponTool;
            inventorySprites[0].sprite = weaponTool.GetComponent<IWeaponTool>().Get2DSpriteTexture();
        }
        
    }

    public void ToggleEquipped(int num)
    {
        if(equipped == inventoryDisplay[num])
        {
            inventoryDisplay[num].GetComponent<IWeaponTool>().UnEquip();
            equipped = null;
            numEquipped = -1;
            Debug.Log($"Has UNEquipped {num}");
        }
        else
        {
            inventoryDisplay[num].GetComponent<IWeaponTool>().Equip();
            equipped = inventoryDisplay[num];
            numEquipped = num;
            Debug.Log($"Has Equipped {num}");
        }
    }

    public GameObject GetEquipped()
    {
        return hasEquipped ? inventoryDisplay[numEquipped] : null;
    }
    public void DelEquipped()
    {
        if(hasEquipped)
        {
            int old = numEquipped;
            GameObject oldGO = inventoryDisplay[old];
            numEquipped = -1;
            inventoryDisplay[old] = null;
            inventorySprites[old].sprite = emptyInventorySlot;
        }
    }
}
