using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float sensitivity;

    Camera firstPerson;
    Vector3 forward;
    Vector3 right;

    





    // Start is called before the first frame update
    void Start()
    {
        firstPerson = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = (Input.mousePosition.x / Screen.width) - 0.5f;
        float mouseY = (Input.mousePosition.y / Screen.height) - 0.5f;
        firstPerson.transform.localRotation = Quaternion.Euler(new Vector4(-(mouseY * 180f), mouseX * 360f, transform.localRotation.z));


        forward = firstPerson.transform.forward;
        right = firstPerson.transform.right;
        forward.y = 0f;
        right.y = 0f;



        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(forward * Time.deltaTime * speed);   
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(forward * Time.deltaTime * -speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(right * Time.deltaTime * -speed / 2 );
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(right * Time.deltaTime * speed / 2);
        }
        
    }

    private void FixedUpdate()
    {
        /*float rotateHorizontal = Input.GetAxis("Mouse X");
        float rotateVertical = Input.GetAxis("Mouse Y");
        transform.Rotate(-firstPerson.transform.up * rotateHorizontal * sensitivity);
        firstPerson.transform.Rotate(firstPerson.transform.right * rotateVertical * sensitivity);
        transform.Rotate(-transform.up * rotateHorizontal * sensitivity);
        forward = firstPerson.transform.forward;
        right = firstPerson.transform.right;
        forward.y = 0f;
        right.y = 0f;*/
    }
}
