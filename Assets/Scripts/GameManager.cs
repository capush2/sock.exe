using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool inSpecialScene = false;
    // Start is called before the first frame update
    [SerializeField] private UIManager uIManager;
    private bool cursorLocked;
    public bool CanPlayerMoveFree
    {
        get
        {
            return !inSpecialScene;
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
            ToggleTablet();
        }
    }

    public void ToggleTablet()
    {
        if (cursorLocked)
        {
            inSpecialScene = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            inSpecialScene = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        uIManager.ToggleTablet();
        cursorLocked = !cursorLocked;
    }

    public void SendPlayerTip(string key)
    {
        if (key.Equals(string.Empty))
        {
            uIManager.ClearDisplay();
            return;
        }
        uIManager.Display($"Press {key.ToUpperInvariant()}");
    }

    public void SendPlayerMessage(string message)
    {
        if (message.Equals(string.Empty))
        {
            uIManager.ClearDisplay();
            return;
        }
        uIManager.Display(message);
    }
}
