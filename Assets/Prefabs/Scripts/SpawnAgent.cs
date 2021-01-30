using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAgent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nagent;
    public GameObject goalObj;
    void Start()
    {
        Invoke("spawn", 2);
    }

    void spawn()
    {
        GameObject na = (GameObject)Instantiate(nagent, this.transform.position, Quaternion.identity);
        na.GetComponent<NavAgentAI>().goal = goalObj.transform;
        //Invoke("spawn", Random.Range(2, 5));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
