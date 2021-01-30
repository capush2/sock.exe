using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMine : WeaponTool
{
    [SerializeField] private ParticleSystem explosion;
    private float triggerAngle = 30f;

    private bool isPlaced = false;
    private Quaternion trigger = Quaternion.identity;
    public override bool Use(RaycastHit hit)
    {
        
        if (hit.transform != null && hit.transform.tag == "Door")
        {
            //EDIT: ca fait 2 min que je l'ai codé pi jme rappel pu comment ca marche
            //Ne pas changer
            Transform target = hit.transform;
            GameObject intruder = new GameObject();
            intruder.transform.parent = target;
            gameObject.SetActive(true);
            transform.parent = intruder.transform;
            transform.position = hit.point;



            transform.eulerAngles = (hit.normal + Vector3.up) * 90;
            transform.parent = target;
            Destroy(intruder);
            //Fin du bloc de no edit

            trigger = transform.rotation;
            isPlaced = true;
            


            return true;
        }
        return false;
    }

    private void FixedUpdate()
    {
        if(isPlaced && Quaternion.Angle(trigger,transform.rotation) > triggerAngle)
        {
            ParticleSystem exp = Instantiate(explosion,transform.position,Quaternion.identity);
            exp.Play();
            Debug.Log("Boom");
            Destroy(gameObject);
            Destroy(exp, 10);
        }
    }
    public override void Equip()
    {
        GameObject rightHand = GameObject.FindGameObjectWithTag("RightHandPos");
        gameObject.transform.position = rightHand.transform.position;
        gameObject.transform.parent = rightHand.transform;
        base.Equip();
    }
}
