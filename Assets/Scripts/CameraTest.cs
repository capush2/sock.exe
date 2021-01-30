using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float mouseSensitivity = 5;
    [SerializeField] private float rayHeight = 1.6f;
    [SerializeField] private float jumpForce = 25;
    [SerializeField] private float runBoost = 2f;
    [SerializeField] private float crouchSpeed = 0.03f;

    [SerializeField] private InventoryUIManager inventory;
    [SerializeField] private GameManager manager;
    private Transform lastLooked = null;


    private Rigidbody rb;
    private Camera cam;


    private bool grounded = false;
    private float runMult = 1;

    //TODO high jump on crouch?


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (manager.CanPlayerMoveFree)
        {
            DebugEscape();
            Equip();
            PickupWeaponTool();
            UseEquippedWTool();
            HighlightView();
        }
    }

    private void DebugEscape()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void FixedUpdate()
    {
        if (manager.CanPlayerMoveFree)
        {
            Move();
            Look();
            Jump();
            Run();
            Crouch();
        }
    }

    private void Move()
    {
        transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * speed * Time.deltaTime * runMult, Space.Self);
        transform.Translate(Input.GetAxis("Horizontal") * Vector3.right * speed * Time.deltaTime, Space.Self);
    }

    private void Look()
    {
        float newX = cam.transform.eulerAngles.x - Input.GetAxis("Mouse Y") * mouseSensitivity;
        float newY = transform.eulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;
        if ((newX + 90) % 360 < 0 || (newX + 90) % 360 > 180)
        {
            newX = cam.transform.eulerAngles.x;
        }
        cam.transform.eulerAngles = new Vector3(newX, cam.transform.eulerAngles.y);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, newY);
    }

    private void Crouch()
    {
        CapsuleCollider col = GetComponent<CapsuleCollider>();
        Transform body = transform.Find("Body").transform;

        if (Input.GetKey(KeyCode.LeftControl) && body.localScale.y > 1)
        {
            body.localScale -= new Vector3(0, crouchSpeed, 0);
            col.height -= 2 * crouchSpeed;
        }
        else if (!Input.GetKey(KeyCode.LeftControl) && body.localScale.y < 1.5f)
        {
            body.localScale += new Vector3(0, crouchSpeed, 0);
            col.height += 2 * crouchSpeed;
        }
    }

    private void Jump()
    {
        CheckGrounded();
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
            grounded = false;
        }
    }

    private void Run()
    {
        runMult = 1;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            runMult = runBoost;
        }
    }

    private void CheckGrounded()
    {
        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, Vector3.down * rayHeight);

        if (Physics.Raycast(landingRay, out hit, rayHeight))
        {
            grounded = true;
        }
    }

    private void HighlightView()
    {
        RaycastHit hitView;
        Ray highlightRay = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(cam.transform.position, cam.transform.forward * 10);

        if (Physics.Raycast(highlightRay, out hitView, 10))
        {
            if (hitView.transform.tag == "WeaponTool")
            {
                if (lastLooked != hitView.transform)
                {
                    lastLooked = hitView.transform;
                    lastLooked.GetComponent<IWeaponTool>().ToggleFlash();
                }
            }
            else if (lastLooked != null)
            {
                lastLooked.GetComponent<IWeaponTool>().ToggleFlash();
                lastLooked = null;
            }
        }
        else
        {
            if (lastLooked != null)
            {
                lastLooked.GetComponent<IWeaponTool>().ToggleFlash();
            }

            lastLooked = null;
        }
    }

    private void PickupWeaponTool()
    {
        if (lastLooked != null && Input.GetKeyDown(KeyCode.F))
        {
            lastLooked.gameObject.SetActive(false);
            inventory.AddToInventory(lastLooked.gameObject);
        }
    }

    private void UseEquippedWTool()
    {
        if (Input.GetMouseButtonDown(0) && inventory.hasEquipped)
        {
            RaycastHit hitTool;
            Ray highlightRay = new Ray(cam.transform.position, cam.transform.forward);
            Debug.DrawRay(cam.transform.position, cam.transform.forward * 10);
            Physics.Raycast(highlightRay, out hitTool, 10);
            if (inventory.GetEquipped().GetComponent<IWeaponTool>().Use(hitTool))
            {
                inventory.DelEquipped();
            }
            Debug.Log($"Uses equipped {inventory.GetEquipped()?.name}");
        }

    }
    private void Equip()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            inventory.ToggleEquipped(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            inventory.ToggleEquipped(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            inventory.ToggleEquipped(2);
    }
}
