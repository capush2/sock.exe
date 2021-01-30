using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentAI : LivingThing
{
    const float BASE_HEIGHT = 4f, MIN_X = -30f, MAX_X = 30f, MAX_Y = 10f, MIN_Z = -30f, MAX_Z = 30f;
    [SerializeField]
    public Transform[] goals;
    [SerializeField] public float speed = 8f;
    [SerializeField] public float runSpeed = 16f;
    [SerializeField] public float radius = 10f;
    float destinationReachedTreshold = 1.01f;
    private int currentPoint;
    NavMeshAgent agent;
    private Transform player;
    bool isRunningAway = false;
    [SerializeField] bool isHardToCatch = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GenGoals(ref agent, isHardToCatch);        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsDestinationReach())
        {
            if (isHardToCatch)
            {
                agent.SetDestination(new Vector3(Random.Range(MIN_X, MAX_X), MAX_Y - ((MAX_Y - 1) * Random.Range(0, 1)), Random.Range(MIN_Z, MAX_Z)));
            } else
            {
                currentPoint++;
                currentPoint %= goals.Length;
                print("Current index " + currentPoint);
                agent.SetDestination(goals[currentPoint].position);
                agent.speed = speed;
                isRunningAway = false;
            }
            
        }
        
        if((player.position.x > agent.transform.position.x - agent.radius &&  player.position.x < agent.transform.position.x + agent.radius) && (player.position.y > agent.transform.position.y - agent.radius && player.position.y < agent.transform.position.y + agent.radius) && (player.position.z > agent.transform.position.z - agent.radius && player.position.z < agent.transform.position.z + agent.radius)) 
        {
            RunAway();
        }
    }
    bool IsDestinationReach()
    {
        float distanceToTarget = Vector3.Distance(agent.transform.position, agent.destination);
        return distanceToTarget < destinationReachedTreshold;
        
    }
    public void GenGoals(ref NavMeshAgent agent, bool isHard)
    {
        isHardToCatch = isHard;
        if (isHardToCatch) {
            agent.SetDestination(new Vector3(Random.Range(MIN_X, MAX_X), MAX_Y - ((MAX_Y - 1) * Random.Range(0, 1)), Random.Range(MIN_Z, MAX_Z)));
        }
        else 
        {
            int nbPoint = Random.Range(2, 10);
            goals = new Transform[nbPoint];
            for (int i = 0; i < nbPoint; i++)
            {
                goals[i] =  new GameObject("goal").transform;
                goals[i].Translate(new Vector3(Random.Range(MIN_X, MAX_X), MAX_Y - ((MAX_Y - 1) * Random.Range(0, 1)), Random.Range(MIN_Z, MAX_Z)));
               
            }
            currentPoint = 0;
            agent.SetDestination(goals[currentPoint].position);
            agent.speed = speed;
            agent.radius = radius;
            player = GameObject.FindWithTag("Player").transform;
        }
    }

    void Run()
    {
        agent.speed = runSpeed;
    }

    void RunAway()
    {
        if(!isRunningAway)
        {
            Run();
            Vector3 awayDest = new Vector3();
            if (Mathf.Abs(player.position.x) > Mathf.Abs(player.position.z))
            {
                if (player.position.x < 0)
                {
                    awayDest.x = Random.Range(agent.transform.position.x, MAX_X);
                }
                else
                {
                    awayDest.x = Random.Range(MIN_X, player.position.x);
                }
                awayDest.z = Random.Range(MIN_Z, MAX_Z);
            }
            else
            {
                awayDest.x = Random.Range(MIN_X, MAX_X);
                if (agent.transform.position.z < 0)
                {
                    awayDest.x = Random.Range(player.position.z, MAX_Z);
                }
                else
                {
                    awayDest.x = Random.Range(MIN_Z, player.position.z);
                }
            }
            awayDest.y = agent.transform.position.y;
            agent.SetDestination(awayDest);
            isRunningAway = true;
        }
         
    }

    #region LivingThing

    override public void OnBearTrapHit()
    {
        base.OnBearTrapHit();
        throw new System.NotImplementedException();
    }

    public override void OnMineHit()
    {
        base.OnMineHit();
        throw new System.NotImplementedException();
    }

    public override void OnNailHit()
    {
        base.OnNailHit();
        throw new System.NotImplementedException();
    }

    #endregion

}
