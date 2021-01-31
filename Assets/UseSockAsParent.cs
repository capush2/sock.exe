using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseSockAsParent : MonoBehaviour
{
    private GameObject female, male;
    private Button theButton;
    public static int Count = 0;
    private Transform parentT;
    private Vector3 initLocalPos;
    private bool selected = false;
    void Start()
    {
        parentT = transform.parent;
        initLocalPos = transform.parent.position;
        theButton = GetComponent<Button>();
        theButton.onClick.AddListener(UseAParent);
        female = GameObject.Find("Femelle");
        male = GameObject.Find("Male");
    }

    void UseAParent()
    {
        if (!selected)
        {
            selected = true;
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
        } else
        {
            Debug.Log("reclicked");
            selected = false;
            transform.parent.SetParent(parentT);
            transform.parent.position = initLocalPos;
        }
    }
}
