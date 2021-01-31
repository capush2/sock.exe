using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyMine : MonoBehaviour
{
    [SerializeField] GameObject mine;
    [SerializeField] GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(AddMine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddMine()
    {
        if (GameManager.money >= 100)
        {
            GameManager.money -= 100;
            mine = Instantiate(mine);
            mine.transform.Translate(20f, 2.5f, 76f);
            gm.SendPlayerMessage("Mine bought!");
        }
        else
        {
            gm.SendPlayerMessage("Not enought money");
        }
    }
}
