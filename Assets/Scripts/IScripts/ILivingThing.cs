using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class LivingThing:MonoBehaviour
{
    virtual public void OnMineHit()
    {
        Debug.Log(gameObject.ToString() + "Was hit by mine and has no behavior");
    }
    virtual public void OnBearTrapHit()
    {
        Debug.Log(gameObject.ToString() + "Was hit by bear trap and has no behavior");
    }
    virtual public void OnNailHit()
    {
        Debug.Log(gameObject.ToString() + "Was hit by nail and has no behavior");
    }

}