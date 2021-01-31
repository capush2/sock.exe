using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DO NOT CHANGE THE ORDER, VERY HARDCODED
public enum PossibleColors
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
    Pink
}

public class SockColor : MonoBehaviour
{
    [SerializeField] private GameObject[] piecesToColor;
    [SerializeField] private Material[] materialColors;

    public PossibleColors[] color;

    // Start is called before the first frame update
    void Awake()
    {
        color = new PossibleColors[piecesToColor.Length];
        float nbColors = materialColors.Length;

        for (int i = 0; i < piecesToColor.Length; i++)
        {
            color[i] = (PossibleColors)Random.Range(0, nbColors - 1);
            changeColor(i);
        }
    }

    private void changeColor(int index)
    {
        piecesToColor[index].GetComponent<SkinnedMeshRenderer>().material = materialColors[(int)color[index]];
    }

    static public PossibleColors mixColor(PossibleColors first, PossibleColors second)
    {
        switch (first)
        {
            case PossibleColors.Red:
                switch (second)
                {
                    case PossibleColors.Blue:
                        return PossibleColors.Purple;
                    case PossibleColors.Yellow:
                        return PossibleColors.Orange;
                    case PossibleColors.White:
                        return PossibleColors.Pink;
                    default:
                        break;
                }
                break;
            case PossibleColors.Blue:
                switch (second)
                {
                    case PossibleColors.Red:
                        return PossibleColors.Purple;
                    case PossibleColors.Yellow:
                        return PossibleColors.Green;
                    default:
                        break;
                }
                break;
            case PossibleColors.Yellow:
                switch (second)
                {
                    case PossibleColors.Red:
                        return PossibleColors.Orange;
                    case PossibleColors.Blue:
                        return PossibleColors.Green;
                    default:
                        break;
                }
                break;
            case PossibleColors.White:
                switch (second)
                {
                    case PossibleColors.Red:
                        return PossibleColors.Pink;
                    case PossibleColors.Black:
                        return PossibleColors.Gray;
                    default:
                        break;
                }
                break;
            case PossibleColors.Black:
                if (second == PossibleColors.White)
                    return PossibleColors.Gray;
                break;
        }
        return Random.Range(0, 1) == 1 ? first : second;
    }

    public static Color32 GetColorCode(PossibleColors color) 
    {
        switch (color)
        {

            case PossibleColors.Red:
                return new Color32(130, 13, 20, 255);

            case PossibleColors.Blue:
                return new Color32(9, 10, 183, 255);

            case PossibleColors.Yellow:
                return new Color32(255, 234, 0, 255);

            case PossibleColors.Purple:
                return new Color32(98, 0, 185, 255);

            case PossibleColors.Orange:
                return new Color32(233, 98, 0, 255);

            case PossibleColors.Green:
                return new Color32(0, 140, 18, 255);
                            
            case PossibleColors.Black:
                return new Color32(0, 0, 0, 255);

            case PossibleColors.Gray:
                return new Color32(72, 72, 72, 255);

            case PossibleColors.Pink:
                return new Color32(173, 0, 149, 255);

            case PossibleColors.White:
            default:
                return new Color32(255, 255, 255, 255);
        }

        
    }

}
