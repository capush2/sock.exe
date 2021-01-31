using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text PlayerTips;
    [SerializeField] private GameObject tablet;

    public void ToggleTablet()
    {
        tablet.SetActive(!tablet.activeSelf);
    }

    public void Display(string message)
    {
        PlayerTips.text = message;
        PlayerTips.transform.parent.GetComponent<Image>().enabled = true;
    }

    public void ClearDisplay()
    {
        PlayerTips.text = "";
        PlayerTips.transform.parent.GetComponent<Image>().enabled = false;
    }
}
