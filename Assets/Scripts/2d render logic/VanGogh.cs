using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VanGogh : MonoBehaviour
{
    [SerializeField] PossibleColors primaryColor;
    [SerializeField] PossibleColors secondaryColor;
    [SerializeField] PossibleColors terceryColor;
    Image[] socks;

    public void ApplyTheStyle(PossibleColors prim, PossibleColors sec, PossibleColors terc)
    {
        primaryColor = prim;
        secondaryColor = sec;
        terceryColor = terc;
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
    public PossibleColors[] GetArray()
    {
        return new PossibleColors[3] { primaryColor, secondaryColor, terceryColor};
    }

    
}
