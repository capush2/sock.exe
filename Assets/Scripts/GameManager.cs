using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool inSpecialScene = true;
    // Start is called before the first frame update
    [SerializeField] private UIManager uIManager;
    private bool cursorLocked;
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
        Cursor.lockState = CursorLockMode.Locked;
        cursorLocked = true;
        //StartCoroutine("IntroductionScene");
    }

    // Update is called once per frame
    void Update()
    {
        HandleCursor();
    }

    //IEnumerator IntroductionScene()
    //{

    //}

    void HandleCursor()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (cursorLocked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            cursorLocked = !cursorLocked;
            //UIManager.ToggleTablet();
        }
    }
}
