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
    private string[] loadedPrompts = new string[14];
    private void Start()
    {
        theButton = GetComponent<Button>();
        theButton.onClick.AddListener(TaskOnClick);
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
    }

    void TaskOnClick()
    {
        tablet.ChangeSprite(0);
        contractGroup.SetActive(true);
        foreach(var p in prompts)
        {
            p.GetComponent<Text>().text = loadedPrompts[Random.Range(0,13)];
        }
        gameObject.SetActive(false);
    }
}
