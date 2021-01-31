using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VanGogh : MonoBehaviour
{
    [SerializeField] Color primaryColor = Color.blue;
    [SerializeField] Color secondaryColor = Color.red;
    [SerializeField] Color terceryColor = Color.green;
    Image[] socks;
    // Start is called before the first frame update
    void Start()
    {
        applyTheStyle(primaryColor, secondaryColor, terceryColor);
    }

    public void applyTheStyle(Color prim, Color sec, Color terc)
    {
        socks = GetComponentsInChildren<Image>();
        for(int i = 0; i < socks.Length; i++)
        {
            if(socks[i].tag == "toes")
            {
                socks[i].color = prim;
            }
            if (socks[i].tag == "collar")
            {
                socks[i].color = terc;
            }
            if (socks[i].tag == "fold")
            {
                socks[i].color = sec;
            }
        }
        
    }

    
}
