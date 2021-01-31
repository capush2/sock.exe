using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SockColorBreeding : MonoBehaviour
{
    private enum PossibleColors
    {
        Red,
        Blue,
        Yellow,
        Purple,
        Orange,
        Green,
        White,
        Black,
        Gray,
        Pink,
        Size
    }

    PossibleColors color;

    // Start is called before the first frame update
    void Start()
    {
        //color = Random.Range(0, PossibleColors.Size - 1)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
