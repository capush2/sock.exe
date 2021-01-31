using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletSpritesContainer : MonoBehaviour
{
    [SerializeField] private Sprite[] tabletStates;
    private int selected = 0;
    public void Start()
    {
        GetComponent<Image>().sprite = tabletStates[selected];
    }
    public void ChangeSprite()
    {
        if(selected == 0)
        {
            selected = 1;
            GetComponent<Image>().sprite = tabletStates[selected];
        }
        else
        {
            selected = 0;
            GetComponent<Image>().sprite = tabletStates[selected];
        }
    }
}
