using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContractButton : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject homeButton;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        ContractGroupManager manager = transform.parent.parent.Find("Apps").Find("AppContracts").GetComponent<ContractGroupManager>();
        if (!manager.acceptedContract)
        {
            manager.acceptedContract = true;
            manager.targetedSock = transform.Find("Sock(Clone)").gameObject;
            Debug.Log(manager.targetedSock.name);
            homeButton.GetComponent<HomeButton>().ClickedOn();
            gameManager.ToggleTablet();
        } else
        {
            int toRemove = -1;
            for(int i = 0; i<GameObject.FindGameObjectWithTag("Player").GetComponent<CameraTest>().SockInventory.Count; i++)
            {
                if(CompareArrayColor(GameObject.FindGameObjectWithTag("Player").GetComponent<CameraTest>().SockInventory[i].GetComponent<VanGogh>().GetArray(), manager.targetedSock.GetComponent<VanGogh>().GetArray()))
                {
                    Debug.Log("Succeed contract");
                    GameManager.money += 200;
                    manager.acceptedContract = false;
                    homeButton.GetComponent<HomeButton>().ClickedOn();
                    gameManager.ToggleTablet();
                    toRemove = i;
                    break;
                }
            }
            if (toRemove != -1)
            {
                Destroy(GameObject.FindGameObjectWithTag("Player").GetComponent<CameraTest>().SockInventory[toRemove].gameObject);
                GameObject.FindGameObjectWithTag("Player").GetComponent<CameraTest>().SockInventory.RemoveAt(toRemove);
            }
            
        }
    }

    bool CompareArrayColor(PossibleColors[] arr1, PossibleColors[] arr2)
    {
        return arr1[0] == arr2[0] && arr1[1] == arr2[1] && arr2[2] == arr1[2];
    }


}
