using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapTest : MonoBehaviour
{
    private const float SPEED = 10;
    private const float JUMP_FORCE = 75;
    [SerializeField] private float speed = 10;
    [SerializeField] private float mouseSensitivity = 5;
    [SerializeField] private float rayHeight = 1.6f;
    [SerializeField] private float jumpForce = 75;
    [SerializeField] private float runBoost = 2f;
    [SerializeField] private float crouchSpeed = 0.03f;

    private GameObject[] inventory = new GameObject[3];
    private Transform lastLooked = null;


    private Rigidbody rb;
    private Camera cam;


    private bool grounded = false;
    private float runMult = 1;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 forward = cam.transform.forward;
        forward.y = 0;
        forward.Normalize();
        Vector3 right = Vector3.Cross(forward, Vector3.up);

        transform.Translate(Input.GetAxis("Vertical") * forward * speed * Time.deltaTime * runMult);
        transform.Translate(-Input.GetAxis("Horizontal") * right * speed * Time.deltaTime);
        cam.transform.eulerAngles += new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * mouseSensitivity;

        Jump();
        Run();
        Crouch();
        HighlightView();
    }


    private void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl) && transform.localScale.y > 1)
        {
            transform.localScale -= new Vector3(0, crouchSpeed, 0);
        }
        else if (!Input.GetKey(KeyCode.LeftControl) && transform.localScale.y < 1.5f)
        {
            transform.localScale += new Vector3(0, crouchSpeed, 0);
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
                    Debug.Log("hitWeapon");
                }
            }
            else if (lastLooked != null)
            {
                lastLooked.GetComponent<IWeaponTool>().ToggleFlash();
                lastLooked = null;
                Debug.Log("not a weapon");
            }
        }
        else
        {
            if (lastLooked != null)
            {
                lastLooked.GetComponent<IWeaponTool>().ToggleFlash();
            }

            lastLooked = null;
            Debug.Log("hit nothing");
        }
    }

    public void Stop()
    {
        speed = 0;
        jumpForce = 0;
    }

    public void BreakFree()
    {
        speed = SPEED;
        jumpForce = JUMP_FORCE;
    }
}
