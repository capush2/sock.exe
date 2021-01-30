using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool inSpecialScene = true;
    // Start is called before the first frame update
    [SerializeField] private UIManager uIManager;
    public bool CanPlayerMoveFree
    {
        get
        {
            return true;
        }
    }

    void Awake()
    {
        //Vérifier sauvegarde
        //Si oui, load

    }

    void Start()
    {
        //StartCoroutine("IntroductionScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //IEnumerator IntroductionScene()
    //{

    //}
}
