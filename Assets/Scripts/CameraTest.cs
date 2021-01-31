using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : LivingThing
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float mouseSensitivity = 5;
    [SerializeField] private float rayHeight = 2f;
    [SerializeField] private float jumpForce = 25;
    [SerializeField] private float runBoost = 2f;
    [SerializeField] private float crouchSpeed = 0.03f;

    [SerializeField] private InventoryUIManager inventory;
    [SerializeField] private GameManager manager;
    [SerializeField] private GameObject prefabPicture;

    private Transform lastLooked = null;

    private Rigidbody rb;
    private Camera cam;


    private bool grounded = false;
    private float runMult = 1;

    [SerializeField] public List<GameObject> SockInventory = new List<GameObject>(9);

    #region LivingThingVar
    [SerializeField] private Vector3 home = Vector3.zero;
    [SerializeField] private Vector3 p1 = Vector3.zero;
    [SerializeField] private Vector3 p2 = Vector3.zero;
    private Vector3 deathPos = Vector3.zero;
    float counter = 0;
    [SerializeField ]float flySpeed = 1f;

    #endregion

    //TODO high jump on crouch?


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
        TestMBAs();
    }

    private void TestMBAs()
    {
        GameObject current = Instantiate(prefabPicture);
        current.GetComponent<VanGogh>().ApplyTheStyle(PossibleColors.Black, PossibleColors.Black, PossibleColors.Black);
        SockInventory.Add(current);
        current.SetActive(false);
        GameObject current2 = Instantiate(prefabPicture);
        current2.GetComponent<VanGogh>().ApplyTheStyle(PossibleColors.Red, PossibleColors.Yellow, PossibleColors.Black);
        SockInventory.Add(current2);
        current2.SetActive(false);
        GameObject current3 = Instantiate(prefabPicture);
        current3.GetComponent<VanGogh>().ApplyTheStyle(PossibleColors.Pink, PossibleColors.Green, PossibleColors.Gray);
        SockInventory.Add(current3);
        current3.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (manager.CanPlayerMoveFree)
        {
            Equip();
            PickupWeaponTool();
            UseEquippedWTool();
            HighlightView();
            TipSock();
        }
    }

    private void TipSock()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 3, 1 << 10);
        GameObject deadSock = null;
        foreach(Collider col in cols)
        {
            if(col.transform.tag != "Player" && col.GetComponent<NavAgentAI>().IsDead)
            {
                deadSock = col.gameObject;
            }
        }
        if(deadSock != null)
        {
            manager.SendPlayerTip("F");
            StartCoroutine("ClearTip");
        }

        if (deadSock == null)
            return;

        if (Input.GetKeyDown(KeyCode.F) && SockInventory.Count < 9)
        {
            GameObject current = Instantiate(prefabPicture);
            current.GetComponent<VanGogh>().ApplyTheStyle(deadSock.GetComponent<SockColor>().color[0], deadSock.GetComponent<SockColor>().color[1], deadSock.GetComponent<SockColor>().color[2]);
            SockInventory.Add(current);
            current.SetActive(false);
            deadSock.SetActive(false);
            StartCoroutine(ShowPickSock());
        }
    }

    IEnumerator ClearTip()
    {
        yield return new WaitForSeconds(2);
        manager.SendPlayerTip("");
    }

    IEnumerator ShowPickSock()
    {
        manager.SendPlayerMessage("Sock added to inventory");
        yield return new WaitForSeconds(2);
        manager.SendPlayerMessage("");
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
                    lastLooked.GetComponent<WeaponTool>().ToggleFlash();
                    if(!lastLooked.GetComponent<WeaponTool>().Used)
                        manager.SendPlayerTip("F");
                }
            }
            else if (lastLooked != null)
            {
                lastLooked.GetComponent<IWeaponTool>().ToggleFlash();
                lastLooked = null;
                manager.SendPlayerTip("");
            }
        }
        else
        {
            if (lastLooked != null)
            {
                lastLooked.GetComponent<IWeaponTool>().ToggleFlash();
            }

            lastLooked = null;
            manager.SendPlayerTip("");
        }
    }

    private void PickupWeaponTool()
    {
        if (lastLooked != null && Input.GetKeyDown(KeyCode.F) && !lastLooked.GetComponent<WeaponTool>().Used)
        {
            lastLooked.gameObject.SetActive(false);
            inventory.AddToInventory(lastLooked.gameObject);
            lastLooked.gameObject.transform.parent = gameObject.transform;
        }
    }

    private void UseEquippedWTool()
    {
        if (Input.GetMouseButtonDown(0) && inventory.hasEquipped)
        {
            RaycastHit hitTool;
            Ray highlightRay = new Ray(cam.transform.position, cam.transform.forward);
            Debug.DrawRay(cam.transform.position, cam.transform.forward * 30);
            Physics.Raycast(highlightRay, out hitTool, 30);
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

    private IEnumerator BearDelay()
    {
        float prevSpeed = speed;
        float prevJmpForce = jumpForce;
        speed = 0;
        jumpForce = 0;
        yield return new WaitForSecondsRealtime(5);
        speed = prevSpeed;
        jumpForce = prevJmpForce;
    }

    #region LivingThing

    override public void OnBearTrapHit()
    {
        StartCoroutine(BearDelay());
    }

    public override void OnMineHit()
    {
        counter = 0;
        deathPos = transform.position;
        rb.isKinematic = true;
        StartCoroutine("GoHome");
    }

    public override void OnTideHit()
    {
        base.OnTideHit();
        throw new System.NotImplementedException();
    }

    IEnumerator GoHome()
    {
        for(; ; )
        {
            
            float u = 1f - counter;
            float t2 = counter * counter;
            float u2 = u * u;
            float u3 = u2 * u;
            float t3 = t2 * counter;
            // Still firing
            Vector3 result =
                    (u3) * deathPos +
                    (3f * u2 * counter) * p1 +
                    (3f * u * t2) * p2 +
                    (t3) * home;


            // Move the transform
            transform.position = result;

            // Update Counter
            counter += flySpeed/1000000;

            // Break the loop
            if (counter >= 1)
            {
                Debug.Log("break");
                rb.isKinematic = false;
                yield break;
            }
            Debug.Log(counter);
            yield return null;
        }
    }

    #endregion
}
