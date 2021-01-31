using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetMoney : MonoBehaviour
{
    Text label;
    // Start is called before the first frame update
    void Start()
    {
        label = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string compare = GameManager.money.ToString() + " $";
        if (compare != label.text)
            label.text = compare;
    }
}
