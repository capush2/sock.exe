using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoomRandom : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabArray;
    private GameObject current;
    [SerializeField] private GameObject[] walls;
    [SerializeField] private GameObject[] a;
    public NavMeshSurface surface;
    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                current = Instantiate(prefabArray[Random.Range(0, prefabArray.Length)]);
                current.transform.position = new Vector3(20 * i - 20, 0, 20 * k - 20);
                current.transform.eulerAngles += new Vector3(0, Random.Range(-1, 1) * 90, 0);
                current.transform.parent = transform;
            }
        }
                
        surface.BuildNavMesh();

        for (int i = 0; i < 2; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                current = Instantiate(walls[1]);
                current.transform.position = new Vector3(20 * i - 10, 4, 20 * k - 20);
                current.transform.parent = transform;
            }
        }

        for (int k = 0; k < 2; k++)
        {
            for (int i = 0; i < 3; i++)
            {
                current = Instantiate(walls[1]);
                current.transform.position = new Vector3(20 * i - 20, 4, 20 * k - 10);
                current.transform.eulerAngles += new Vector3(0, 90, 0);
                current.transform.parent = transform;
            }
        }
                
        current = (GameObject) Instantiate(a[0], new Vector3(15, 1, 16), Quaternion.identity);
        GameObject goal = new GameObject("goal");
        goal.transform.Translate(new Vector3(-19, 1, -19));
        current.GetComponent<NavAgentAI>().goal = goal.transform;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
