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

        SpawnWalls();
                
        current = (GameObject) Instantiate(a[0], new Vector3(15, 1, 16), Quaternion.identity);
        GameObject goal = new GameObject("goal");
        goal.transform.Translate(new Vector3(-19, 1, -19));
        current.GetComponent<NavAgentAI>().goal = goal.transform;


    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SpawnWalls()
    {
        List<int> doorsLeft = new List<int>(12);
        for (int i = 0; i < 12; i++)
        {
            doorsLeft.Add(i);
        }

        int[] groups = new int[9];
        for (int i = 0; i < groups.Length; i++)
        {
            groups[i] = i;
        }

        while (!ConnexPath(groups) && doorsLeft.Count > 0)
        {
            int chosen = Random.Range(0, doorsLeft.Count - 1);
            AddDoor(doorsLeft[chosen], groups, true);
            doorsLeft.RemoveAt(chosen);
        }

        foreach (int iter in doorsLeft)
        {
            AddDoor(iter, groups, false);
        }

    }

    private bool ConnexPath(int[] groups)
    {
        bool isConnex = true;
        foreach (int iter in groups)
        {
            isConnex &= iter == 0;
        }
        return isConnex;
    }

    private void AddDoor(int index, int[] groups, bool open)
    {
        int dyingGroup;
        int newGroup;
        GameObject current;
        if (open)
        {
            current = Instantiate(walls[1]);
        }
        else
        {
            current = Instantiate(walls[0]);
        }
        current.transform.parent = transform;


        switch (index)
        {
            case 0:
                newGroup = groups[0];
                dyingGroup = groups[1];
                current.transform.position = new Vector3(-10, 4, 20);
                break;
            case 1:
                newGroup = groups[1];
                dyingGroup = groups[2];
                current.transform.position = new Vector3(10, 4, 20);
                break;
            case 2:
                newGroup = groups[0];
                dyingGroup = groups[3];
                current.transform.position = new Vector3(-20, 4, 10);
                current.transform.eulerAngles += new Vector3(0, 90, 0);
                break;
            case 3:
                newGroup = groups[1];
                dyingGroup = groups[4];
                current.transform.position = new Vector3(0, 4, 10);
                current.transform.eulerAngles += new Vector3(0, 90, 0);
                break;
            case 4:
                newGroup = groups[2];
                dyingGroup = groups[5];
                current.transform.position = new Vector3(20, 4, 10);
                current.transform.eulerAngles += new Vector3(0, 90, 0);
                break;
            case 5:
                newGroup = groups[3];
                dyingGroup = groups[4];
                current.transform.position = new Vector3(-10, 4, 0);
                break;
            case 6:
                newGroup = groups[4];
                dyingGroup = groups[5];
                current.transform.position = new Vector3(10, 4, 0);
                break;
            case 7:
                newGroup = groups[3];
                dyingGroup = groups[6];
                current.transform.position = new Vector3(-20, 4, -10);
                current.transform.eulerAngles += new Vector3(0, 90, 0);
                break;
            case 8:
                newGroup = groups[4];
                dyingGroup = groups[7];
                current.transform.position = new Vector3(0, 4, -10);
                current.transform.eulerAngles += new Vector3(0, 90, 0);
                break;
            case 9:
                newGroup = groups[5];
                dyingGroup = groups[8];
                current.transform.position = new Vector3(20, 4, -10);
                current.transform.eulerAngles += new Vector3(0, 90, 0);
                break;
            case 10:
                newGroup = groups[6];
                dyingGroup = groups[7];
                current.transform.position = new Vector3(-10, 4, -20);
                break;
            case 11:
                newGroup = groups[7];
                dyingGroup = groups[8];
                current.transform.position = new Vector3(10, 4, -20);
                break;
            default:
                newGroup = 0;
                dyingGroup = 0;
                break;
        }

        if (open && dyingGroup != newGroup)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                if (groups[i] == dyingGroup)
                {
                    groups[i] = newGroup;
                }
            }
        }
    }
}
