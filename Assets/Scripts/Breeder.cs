using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Breeder : MonoBehaviour
{
    //To remove once we have the interface going
    [SerializeField] private GameObject male;
    [SerializeField] private GameObject female;

    void Start()
    {
        //This can also be removed
        PossibleColors[] mColors = male.GetComponent<SockColor>().color;
        PossibleColors[] fColors = female.GetComponent<SockColor>().color;
        Breed(mColors, fColors);
    }

    public PossibleColors[] Breed(PossibleColors[] female, PossibleColors[] male)
    {
        PossibleColors[] child = new PossibleColors[3];
        switch (Random.Range(0,3))//primary
        {
            case 0:
                child[0] = female[0];
                break;
            case 1:
                child[0] = SockColor.mixColor(female[0], male[0]);
                break;
            default:
                child[0] = male[0];
                break;
        }

        switch (Random.Range(0, 3))//secondary
        {
            case 0:
                child[1] = male[1];
                break;
            case 1:
                child[1] = SockColor.mixColor(female[1], male[1]);
                break;
            default:
                child[1] = female[1];
                break;
        }

        switch (Random.Range(0, 3))//tiercary
        {
            case 0:
                child[2] = female[2];
                break;
            case 1:
                child[2] = male[2];
                break;
            default:
                child[2] = SockColor.mixColor(female[2], male[2]);
                break;
        }

        Debug.Log(child[0]);
        Debug.Log(child[1]);
        Debug.Log(child[2]);

        return child;
    }
}