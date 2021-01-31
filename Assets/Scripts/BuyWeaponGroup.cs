using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyWeaponGroup : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TabletSpritesContainer tablet;
    [SerializeField] private GameObject weaponGroup;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Afficher);
    }

    public void Afficher()
    {
        tablet.ChangeSprite(0);
        weaponGroup.SetActive(true);
        gameObject.SetActive(false);
    }
}
