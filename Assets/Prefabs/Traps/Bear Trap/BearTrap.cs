using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
    private bool active = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (active)
        {
            transform.GetChild(3).eulerAngles += new Vector3(85, 0, 0);
            transform.GetChild(4).eulerAngles += new Vector3(85, 0, 0);
            active = false;
            other.gameObject.GetComponent<BearTrapTest>().Stop();
            yield return new WaitForSecondsRealtime(5);
            other.gameObject.GetComponent<BearTrapTest>().BreakFree();
        }
    }

}
