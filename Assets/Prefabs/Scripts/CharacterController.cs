using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private int speed = 5;

    private float x;
    private float y;
    private Vector3 rotateValue;
    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection = transform.TransformDirection(Vector3.forward).normalized * speed * Time.deltaTime;
            transform.parent.position += new Vector3(moveDirection.x, 0, moveDirection.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection = transform.TransformDirection(Vector3.left).normalized * speed * Time.deltaTime;
            transform.parent.position += new Vector3(moveDirection.x, 0, moveDirection.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection = transform.TransformDirection(Vector3.back).normalized * speed * Time.deltaTime;
            transform.parent.position += new Vector3(moveDirection.x, 0, moveDirection.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection = transform.TransformDirection(Vector3.right).normalized * speed * Time.deltaTime;
            transform.parent.position += new Vector3(moveDirection.x, 0, moveDirection.z);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.parent.GetComponent<Rigidbody>().AddForce(Vector3.up * 200);
        }

        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");
        rotateValue = new Vector3(-1f * y, x, 0);
        transform.eulerAngles += rotateValue;
    }
}
