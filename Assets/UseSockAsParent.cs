using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseSockAsParent : MonoBehaviour
{
    private GameObject female, male;
    private Button theButton;
    public static int Count = 0;
    void Start()
    {
        theButton = GetComponent<Button>();
        theButton.onClick.AddListener(UseAParent);
        female = GameObject.Find("Femelle");
        male = GameObject.Find("Male");
    }

    void UseAParent()
    {
        GameObject copy = transform.parent.gameObject;
        if (Count % 2 == 0)
        {
            copy.transform.SetParent(female.transform);
        }
        else
        {
            copy.transform.SetParent(male.transform);
        }
        
        copy.transform.localPosition = new Vector3(0, 0, 0);
        Count++;
        copy.GetComponentInChildren<Button>().enabled = false;
    }
}
