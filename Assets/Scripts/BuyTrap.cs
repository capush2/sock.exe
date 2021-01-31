using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyTrap : MonoBehaviour
{
    [SerializeField] GameObject trap;
    [SerializeField] GameManager gm;
    GameObject activeTrap;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(AddTrap);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddTrap()
    {
        if (GameManager.money >= 75)
        {
            GameManager.money -= 75;
            activeTrap = Instantiate(trap);
            activeTrap.transform.Translate(12f, 1.25f, 94f);
            trap.SetActive(true);
            gm.SendPlayerMessage("Trap bought!");
        }
        else
        {
            gm.SendPlayerMessage("Not enought money");
        }
    }
}
