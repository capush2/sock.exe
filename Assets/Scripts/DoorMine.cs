﻿using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMine : WeaponTool
{
    [SerializeField] private ParticleSystem explosion;
    AudioSource source;
    private float triggerAngle = 30f;
    private float expRadius = 10f;

    private Quaternion trigger = Quaternion.identity;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
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
            Used = true;            


            return true;
        }
        return false;
    }

    private void FixedUpdate()
    {
        if(Used && Quaternion.Angle(trigger,transform.rotation) > triggerAngle)
        {
            ParticleSystem exp = Instantiate(explosion,transform.position,Quaternion.identity);

            Collider[] cols = Physics.OverlapSphere(transform.position, expRadius, 1 << 10);
            Debug.Log(1 << 10);
            foreach (Collider col in cols)
            {
                Debug.Log(col.ToString() + "FUCK");
                col.GetComponent<LivingThing>().OnMineHit();
            }

            AudioSource.PlayClipAtPoint(source.clip, source.transform.position);
            exp.Play();
            Destroy(gameObject);
            Destroy(exp, 10);
        }
    }
}
