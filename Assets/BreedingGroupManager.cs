using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreedingGroupManager : MonoBehaviour
{
    Button theButton;
    [SerializeField] private TabletSpritesContainer tablet;
    [SerializeField] private GameObject contractGroup;

    void Start()
    {
        theButton = GetComponent<Button>();
        theButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        tablet.ChangeSprite(0);
        contractGroup.SetActive(true);
        gameObject.SetActive(false);//important doit etre en dernier
    }
}
