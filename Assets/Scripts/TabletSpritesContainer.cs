using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletSpritesContainer : MonoBehaviour
{
    [SerializeField] private Sprite[] tabletStates;
    private int selected = 0;
    [SerializeField] private GameObject[] AppGroup;
    public void Start()
    {
        GetComponent<Image>().sprite = tabletStates[selected];
    }
    public void ChangeSprite(int num)
    {
        if(num == 1)
        {
            selected = 1;
            GetComponent<Image>().sprite = tabletStates[selected];
            foreach(GameObject r in AppGroup)
            {
                r.SetActive(true);
            }
        }
        else
        {
            selected = 0;
            GetComponent<Image>().sprite = tabletStates[selected];
            foreach (GameObject r in AppGroup)
            {
                r.SetActive(false);
            }
        }
    }
}
