using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomRandom : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabArray;
    private GameObject current;
    [SerializeField] private GameObject[] walls;

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
            }
        }

        for (int i = 0; i < 2; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                current = Instantiate(walls[1]);
                current.transform.position = new Vector3(20 * i - 10, 4, 20 * k - 20);
            }
        }

        for (int k = 0; k < 2; k++)
        {
            for (int i = 0; i < 3; i++)
            {
                current = Instantiate(walls[1]);
                current.transform.position = new Vector3(20 * i - 20, 4, 20 * k - 10);
                current.transform.eulerAngles += new Vector3(0, 90, 0);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
