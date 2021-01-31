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
        }
    }
}
