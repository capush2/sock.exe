//TODO define MIN_LIFESPAN,MAX_LIFESPAN
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Sock
{
    public Pattern pattern;
    public Color primaryColor;
    public Color secondaryColor;
    public int lifespanLeft;
    public float fertility; //TODO pt ajouter une influence de lifespanleft
    public bool hasArmor;
    public Modifiers modifiers;
    public bool isMale;
    public bool isOfAge;

    public Sock()
    {

    }

    public Sock(Sock father, Sock mother)
    {
        //isMale = (Random.value > 0.5f);
        //lifespanLeft = Random.Range(MIN_LIFESPAN, MAX_LIFESPAN);
        //fertility = Random.Range(father.fertility, mother.fertility);
        //if (father.hasArmor && mother.hasArmor)
        //    hasArmor = true;
        //else if (father.hasArmor || mother.hasArmor)
        //    hasArmor = (Random.value > 0.5f);
        //else
        //    hasArmor = false;

        //if (Random.value > 0.75)
        //{
        //    pattern = father.pattern;
        //}
        //else
        //{
        //    pattern = mother.pattern;
        //}

        //if (Random.value > 0.75)
        //{
        //    primaryColor = mother.primaryColor;
        //}
        //else
        //{
        //    primaryColor = father.primaryColor;
        //}

        //if (Random.value > 0.5)
        //{
        //    secondaryColor = mother.secondaryColor;
        //}
        //else
        //{
        //    secondaryColor = father.secondaryColor;
        //}

        //modifiers = new Modifiers(pattern, primaryColor, hasArmor);
    }

    public void tickDown()
    {
        lifespanLeft--;
        if (lifespanLeft == 0)
        {
            //TODO DELETE this sock
        }
    }


}