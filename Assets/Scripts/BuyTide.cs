using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyTide : MonoBehaviour
{
    [SerializeField] GameObject tide;
    [SerializeField] GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(AddTide);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddTide()
    {
        if (GameManager.money >= 50)
        {
            GameManager.money -= 50;
            tide = Instantiate(tide);
            tide.transform.Translate(14f, 1.5f, 94f);
            gm.SendPlayerMessage("Tide bought!");

        }
        else
        {
            gm.SendPlayerMessage("Not enought money");
        }
    }
}
