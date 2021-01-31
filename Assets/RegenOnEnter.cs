using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RegenOnEnter : MonoBehaviour
{
    const float MIN_X = -30f, MAX_X = 30f, MAX_Y = 10f, MIN_Z = -30f, MAX_Z = 30f;
    const int MINSOCKS = 3, NBSOCKS = 6;
    private GameObject doorInitial;
    private Quaternion rotInit;
    private Vector3 posInit;
    [SerializeField] private GameObject agent;
    private void Start()
    {
        doorInitial = GameObject.FindGameObjectWithTag("entry");
        rotInit = doorInitial.transform.rotation;
        posInit = doorInitial.transform.position;
    }
    [SerializeField] private RoomRandom r;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject[] tools = GameObject.FindGameObjectsWithTag("WeaponTool");
            foreach (var t in tools)
            {
                if (t.GetComponent<WeaponTool>().Used || t.CompareTag("nail"))
                {
                    t.SetActive(false);
                    Destroy(t.gameObject);
                }
            }
            doorInitial.transform.position = posInit;
            doorInitial.transform.rotation = rotInit;

            GameObject current = Instantiate(agent);
            var agents = new NavMeshAgent[UnityEngine.Random.Range(1, 2)];
            agents[0] = current.GetComponent<NavMeshAgent>();
            for (int i = 0; i < agents.Length; i++)
            {
                agents[i] = Instantiate(agents[0]);
                agents[i].transform.position = new Vector3(UnityEngine.Random.Range(MIN_X, MAX_X), MAX_Y - ((MAX_Y - 1) * UnityEngine.Random.Range(0, 1)), UnityEngine.Random.Range(MIN_Z, MAX_Z));
            }
        }
    }
}
