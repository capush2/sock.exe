using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text PlayerTips;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Tablet");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleTablet()
    {

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
