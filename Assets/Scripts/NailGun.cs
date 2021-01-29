using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailGun : MonoBehaviour, IWeaponTool
{
    [SerializeField]
    GameObject nailPrefab = null;

    [SerializeField]
    Vector3 relativeNailStartCoords = new Vector3(0.29f, -0.01f, 1.04f);

    private bool isEquiped;

    void Awake()
    {
        isEquiped = false;
    }

    void FixedUpdate()
    {
        if(isEquiped && Input.GetMouseButtonDown(0))
        {
            Debug.Log("HasClicked");
            Instantiate(nailPrefab, relativeNailStartCoords, Quaternion.identity, transform);
            gameObject.SetActive(false);
            isEquiped = false;
        }
    }
    /*
    public GameObject Equip()
    {

    }

    public GameObject Use()
    {

    }*/
}
