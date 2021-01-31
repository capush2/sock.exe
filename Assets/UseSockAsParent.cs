using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseSockAsParent : MonoBehaviour
{
    private GameObject female, male;
    private Button theButton;
    void Start()
    {
        theButton = GetComponent<Button>();
        theButton.onClick.AddListener(UseAParent);
        female = GameObject.Find("Femelle");
        male = GameObject.Find("Male");
    }

    void UseAParent()
    {
        GameObject copy = Instantiate(transform.parent.gameObject, female.transform);
        Destroy(copy.GetComponentInChildren<Button>().gameObject);
    }
}
