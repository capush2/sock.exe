using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyGun : MonoBehaviour
{
    [SerializeField] GameObject gun;
    [SerializeField] GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(AddGun);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddGun()
    {
        gun = Instantiate(gun);
        gun.transform.Translate(16f, 0.5f, 94f);
        gm.SendPlayerMessage("Gun bought!");
    }
}
