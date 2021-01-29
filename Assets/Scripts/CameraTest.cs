using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest: MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float mouseSensitivity = 5;
    [SerializeField] private float rayHeight = 1.6f;
    [SerializeField] private float jumpForce = 25;
    [SerializeField] private float runBoost = 2f;
    [SerializeField] private float crouchSpeed = 0.03f;

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
    void Update()
    {
        Vector3 forward = cam.transform.forward;
        forward.y = 0;
        forward.Normalize();
        Vector3 right = Vector3.Cross(forward, Vector3.up);

        transform.Translate(Input.GetAxis("Vertical") * forward * speed*Time.deltaTime * runMult);
        transform.Translate(-Input.GetAxis("Horizontal") * right * speed * Time.deltaTime);
        cam.transform.eulerAngles += new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * mouseSensitivity;

        Jump();
        Run();
        Crouch();
    }


    private void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl) && transform.localScale.y > 1)
        {
            transform.localScale -= new Vector3(0, crouchSpeed, 0);
        }else if(!Input.GetKey(KeyCode.LeftControl) && transform.localScale.y < 1.5f)
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
}
