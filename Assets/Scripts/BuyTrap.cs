using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyTrap : MonoBehaviour
{
    [SerializeField] GameObject trap;
    [SerializeField] GameManager gm;
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
            trap = Instantiate(trap);
            trap.transform.Translate(12f, 1.25f, 94f);
            gm.SendPlayerMessage("Trap bought!");
        }
        else
        {
            gm.SendPlayerMessage("Not enought money");
        }
    }
}
