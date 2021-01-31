using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VanGogh : MonoBehaviour
{
    [SerializeField] PossibleColors primaryColor = PossibleColors.Blue;
    [SerializeField] PossibleColors secondaryColor = PossibleColors.Red;
    [SerializeField] PossibleColors terceryColor = PossibleColors.Green;
    Image[] socks;
    // Start is called before the first frame update
    void Start()
    {
        //applyTheStyle(primaryColor, secondaryColor, terceryColor);
    }

    public void applyTheStyle(PossibleColors prim, PossibleColors sec, PossibleColors terc)
    {
        socks = GetComponentsInChildren<Image>();
        for(int i = 0; i < socks.Length; i++)
        {
            Color32 color;
            if (socks[i].tag == "toes")
            {
                color = SockColor.GetColorCode(prim);
                socks[i].color = color;
            }
            if (socks[i].tag == "collar")
            {
                color = SockColor.GetColorCode(terc);
                socks[i].color = color;
            }
            if (socks[i].tag == "fold")
            {
                color = SockColor.GetColorCode(sec);
                socks[i].color = color;
            }
        }
        
    }

    
}
