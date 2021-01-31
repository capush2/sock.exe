using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContractGroupManager : MonoBehaviour
{
    Button theButton;
    [SerializeField] private TabletSpritesContainer tablet;
    [SerializeField] private GameObject contractGroup;
    [SerializeField] private GameObject[] prompts;
    [SerializeField] private GameObject prefab;
    private string[] loadedPrompts = new string[14];
    public bool acceptedContract = false;
    public GameObject targetedSock;

    private void Start()
    {
        theButton = GetComponent<Button>();
        loadedPrompts[0] = "Oh no! I lost my sock in the laudry again!";
        loadedPrompts[1] = "Thank you, this sock will be a fine addition to my collection.";
        loadedPrompts[2] = "Can you find this sock for me?";
        loadedPrompts[3] = "I want this sock.";
        loadedPrompts[4] = "My dog ate my sock, I need a replacement for it.";
        loadedPrompts[5] = "I went to Tchernobyl and grew a new foot, I need a third sock of this style: ";
        loadedPrompts[6] = "Wanted!";
        loadedPrompts[7] = "My sock is lonely, go find him a friend!";
        loadedPrompts[8] = "Sock looking for love <3!";
        loadedPrompts[9] = "SIA (Sock Intelligence Agency) is looking for this S O C K!";
        loadedPrompts[10] = "Sock on this.";
        loadedPrompts[11] = "There's a hole in my sock, I need a new one.";
        loadedPrompts[12] = "The dryer stole my sock again.";
        loadedPrompts[13] = "S O C K";
        theButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        tablet.ChangeSprite(0);
        contractGroup.SetActive(true);
        if (!acceptedContract)
        {
            GameObject current;
            foreach (var p in prompts)
            {
                p.SetActive(true);
                p.GetComponent<Text>().text = loadedPrompts[Random.Range(0,13)];
                current = Instantiate(prefab);
                current.GetComponent<VanGogh>().ApplyTheStyle((PossibleColors)Random.Range(0,(int)PossibleColors.Size), (PossibleColors)Random.Range(0, (int)PossibleColors.Size), (PossibleColors)Random.Range(0, (int)PossibleColors.Size));
                current.transform.Find("Background").GetComponent<RawImage>().color = p.transform.parent.GetComponent<Button>().colors.normalColor;
                current.transform.Find("Button").gameObject.SetActive(false);
                current.transform.parent = p.transform.parent;
                current.transform.position = current.transform.parent.position + new Vector3(p.transform.parent.GetComponent<RectTransform>().rect.width / 4 - current.GetComponent<RectTransform>().rect.width / 2, 0, 0);
                current.transform.localScale = new Vector3(1.2f, 1.2f);
            }
        } else
        {
            prompts[0].transform.parent.gameObject.SetActive(false);
            prompts[2].transform.parent.gameObject.SetActive(false);
            prompts[1].GetComponent<Text>().text = "This is your current task";
            targetedSock.transform.parent = prompts[1].transform.parent;
            targetedSock.transform.position = targetedSock.transform.parent.position + new Vector3(prompts[1].transform.parent.GetComponent<RectTransform>().rect.width / 4 - targetedSock.GetComponent<RectTransform>().rect.width / 2, 0, 0);
        }
        gameObject.SetActive(false);
    }
}
