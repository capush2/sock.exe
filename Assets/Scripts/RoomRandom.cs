using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoomRandom : MonoBehaviour
{
    const float MIN_X = -30f, MAX_X = 30f, MAX_Y = 10f, MIN_Z = -30f, MAX_Z = 30f;
    const int MINSOCKS = 3, NBSOCKS = 6;
    [SerializeField] private GameObject[] oneRoomTall;
    [SerializeField] private GameObject[] stairs;
    private GameObject current;
    [SerializeField] private GameObject[] walls;
    [SerializeField] private GameObject agent;
    public NavMeshSurface surface;


    private NavMeshAgent[] agents;

    private float floorHeight = 8f;
    

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> randomRooms = ShuffleRooms();

        SpawnRooms(2,randomRooms);
                
        surface.BuildNavMesh();

        for (int i = 0; i < 2; i++)
        {
            SpawnWalls(i * floorHeight);
        }
            

        current = Instantiate(agent);
        agents = new NavMeshAgent[UnityEngine.Random.Range(MINSOCKS, NBSOCKS)];
        agents[0] = current.GetComponent<NavMeshAgent>();
        for (int i = 0; i < agents.Length; i++)
        {
            agents[i] = Instantiate(agents[0]);
            agents[i].transform.position = new Vector3(UnityEngine.Random.Range(MIN_X, MAX_X), MAX_Y - ((MAX_Y - 1) * UnityEngine.Random.Range(0, 1)), UnityEngine.Random.Range(MIN_Z, MAX_Z));
        }
    }

    private void SpawnRooms(int height, List<GameObject> randomRooms)
    {

        for(int floor = 0; floor < height; floor++)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if(randomRooms[9*floor + 3 * i + k].Equals(stairs[0]))
                    {
                        current = Instantiate(stairs[0]);
                        current.transform.position = new Vector3(20 * i - 20, floor * floorHeight, 20 * k - 20);
                        Vector3 rot = new Vector3(0, UnityEngine.Random.Range(-1, 2) * 90, 0);
                        current.transform.eulerAngles += rot;
                        current.transform.parent = transform;
                        GameObject stairTop = Instantiate(stairs[1]);
                        stairTop.transform.parent = current.transform.parent;
                        stairTop.transform.rotation = current.transform.rotation;
                        stairTop.transform.parent = current.transform.parent;
                        stairTop.transform.position = current.transform.position + Vector3.up * floorHeight;
                    }
                    else if (!randomRooms[9*floor + 3 * i + k].Equals(stairs[1]))
                    {
                        current = Instantiate(randomRooms[9 * floor + 3 * i + k]);
                        current.transform.position = new Vector3(20 * i - 20, floor*floorHeight, 20 * k - 20);
                        current.transform.eulerAngles += new Vector3(0, UnityEngine.Random.Range(-1, 1) * 90, 0);
                        current.transform.parent = transform;
                    }
                }
            }
        }
    }

    private List<GameObject> ShuffleRooms()
    {
        List<GameObject> randomRooms = new List<GameObject>();
        randomRooms.AddRange(oneRoomTall);

        for (int i = 0; i < randomRooms.Count; i++)
        {
            GameObject temp = randomRooms[i];
            int randomIndex = UnityEngine.Random.Range(i, randomRooms.Count);
            randomRooms[i] = randomRooms[randomIndex];
            randomRooms[randomIndex] = temp;
        }

        int randomStair = UnityEngine.Random.Range(0, 9);
        randomRooms.Add(randomRooms[randomStair]);
        randomRooms.Add(randomRooms[randomStair + 9]);
        randomRooms[randomStair] = stairs[0];
        randomRooms[randomStair + 9] = stairs[1];
        return randomRooms;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SpawnWalls(float height)
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
            int chosen = UnityEngine.Random.Range(0, doorsLeft.Count - 1);
            AddDoor(doorsLeft[chosen], groups, true, height);
            doorsLeft.RemoveAt(chosen);
        }

        foreach (int iter in doorsLeft)
        {
            AddDoor(iter, groups, false, height);
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

    private void AddDoor(int index, int[] groups, bool open, float height)
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
                current.transform.position = new Vector3(-10, 4 + height, 20);
                break;
            case 1:
                newGroup = groups[1];
                dyingGroup = groups[2];
                current.transform.position = new Vector3(10, 4 + height, 20);
                break;
            case 2:
                newGroup = groups[0];
                dyingGroup = groups[3];
                current.transform.position = new Vector3(-20, 4 + height, 10);
                current.transform.eulerAngles += new Vector3(0, 90, 0);
                break;
            case 3:
                newGroup = groups[1];
                dyingGroup = groups[4];
                current.transform.position = new Vector3(0, 4 + height, 10);
                current.transform.eulerAngles += new Vector3(0, 90, 0);
                break;
            case 4:
                newGroup = groups[2];
                dyingGroup = groups[5];
                current.transform.position = new Vector3(20, 4 + height, 10);
                current.transform.eulerAngles += new Vector3(0, 90, 0);
                break;
            case 5:
                newGroup = groups[3];
                dyingGroup = groups[4];
                current.transform.position = new Vector3(-10, 4 + height, 0);
                break;
            case 6:
                newGroup = groups[4];
                dyingGroup = groups[5];
                current.transform.position = new Vector3(10, 4 + height, 0);
                break;
            case 7:
                newGroup = groups[3];
                dyingGroup = groups[6];
                current.transform.position = new Vector3(-20, 4 + height, -10);
                current.transform.eulerAngles += new Vector3(0, 90, 0);
                break;
            case 8:
                newGroup = groups[4];
                dyingGroup = groups[7];
                current.transform.position = new Vector3(0, 4 + height, -10);
                current.transform.eulerAngles += new Vector3(0, 90, 0);
                break;
            case 9:
                newGroup = groups[5];
                dyingGroup = groups[8];
                current.transform.position = new Vector3(20, 4 + height, -10);
                current.transform.eulerAngles += new Vector3(0, 90, 0);
                break;
            case 10:
                newGroup = groups[6];
                dyingGroup = groups[7];
                current.transform.position = new Vector3(-10, 4 + height, -20);
                break;
            case 11:
                newGroup = groups[7];
                dyingGroup = groups[8];
                current.transform.position = new Vector3(10, 4 + height, -20);
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
