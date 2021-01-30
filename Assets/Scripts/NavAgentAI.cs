using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentAI : MonoBehaviour
{
    const float BASE_HEIGHT = 4f, MIN_X = -30f, MAX_X = 30f, MIN_Z = -30f, MAX_Z = 30f;
    [SerializeField]
    public Transform[] goals;
    [SerializeField] public float speed = 8f;
    [SerializeField] public float runSpeed = 16f;
    [SerializeField] public float radius = 10f;
    private int currentPoint;
    NavMeshAgent agent;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GenGoals(ref agent);        
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0 || agent.isPathStale)
        {
            currentPoint++;
            currentPoint %= goals.Length;
            agent.destination = goals[currentPoint].position;
        }
        
        if((player.position.x > agent.transform.position.x - agent.radius &&  player.position.x < agent.transform.position.x + agent.radius) && (player.position.y > agent.transform.position.y - agent.radius && player.position.y < agent.transform.position.y + agent.radius) && (player.position.z > agent.transform.position.z - agent.radius && player.position.z < agent.transform.position.z + agent.radius)) 
        {
            print("Oh no don't get me daddy!");
            run();
        }

    }

    public void GenGoals(ref NavMeshAgent agent)
    {
        int nbPoint = Random.Range(2, 10);
        goals = new Transform[nbPoint];
        for (int i = 0; i < nbPoint; i++)
        {
            GameObject goal = new GameObject("goal");
            goal.transform.Translate(new Vector3(Random.Range(MIN_X, MAX_X), 1, Random.Range(MIN_Z, MAX_Z)));
            goals[i] =  goal.transform;
        }
        currentPoint = 0;
        agent.destination = goals[currentPoint].position;
        agent.speed = speed;
        agent.radius = radius;
        player = GameObject.FindWithTag("Player").transform;
    }

    void run()
    {
        agent.speed = runSpeed;
    }
}
