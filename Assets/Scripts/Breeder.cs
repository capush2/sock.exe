using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Breeder : MonoBehaviour
{
    [SerializeField] private GameObject male;
    [SerializeField] private GameObject female;
    [SerializeField] private BreedingGroup bgroup;
    [SerializeField] private GameObject prefabPicture;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Breed);
    }

    public void Breed()
    {
        PossibleColors[] mColors = male.GetComponentInChildren<VanGogh>()?.GetArray();
        PossibleColors[] fColors = female.GetComponentInChildren<VanGogh>()?.GetArray();
        if(mColors == null || fColors == null)
        {
            return;
        }
        PossibleColors[] child = new PossibleColors[3];
        switch (Random.Range(0,3))//primary
        {
            case 0:
                child[0] = fColors[0];
                break;
            case 1:
                child[0] = SockColor.mixColor(fColors[0], mColors[0]);
                break;
            default:
                child[0] = mColors[0];
                break;
        }

        switch (Random.Range(0, 3))//secondary
        {
            case 0:
                child[1] = mColors[1];
                break;
            case 1:
                child[1] = SockColor.mixColor(fColors[1], mColors[1]);
                break;
            default:
                child[1] = fColors[1];
                break;
        }

        switch (Random.Range(0, 3))//tiercary
        {
            case 0:
                child[2] = fColors[2];
                break;
            case 1:
                child[2] = mColors[2];
                break;
            default:
                child[2] = SockColor.mixColor(fColors[2], mColors[2]);
                break;
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<CameraTest>().SockInventory.Remove(male.GetComponentInChildren<VanGogh>().gameObject);
        GameObject.FindGameObjectWithTag("Player").GetComponent<CameraTest>().SockInventory.Remove(female.GetComponentInChildren<VanGogh>().gameObject);
        GameObject current = Instantiate(prefabPicture);
        current.GetComponent<VanGogh>().ApplyTheStyle(child[0],child[1],child[2]);
        bgroup.Effacer();
        GameObject.FindGameObjectWithTag("Player").GetComponent<CameraTest>().SockInventory.Add(current);
        bgroup.Afficher();

    }
}