using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GOB : MonoBehaviour
{
    public bool active;
    public bool busy;

    public float hunger;
    public float mate;

    public bool canMate;

    public float hungerRate;
    public float matingRate;

    public float tickRate = 5.0f;
    private float lastTicked = 0f;

    public float huntTimeOut = 10f;
    private bool startedHunt = false;
    private float huntStart;

    public NavMeshAgent agent;

    public string foodType;

    public bool hunted = false;

    public GameObject createWhenMating;
    public bool isPred;
    public CountScript cS;
    

    void Start()
    {
        hunger += Random.Range(0f, 30f);
        cS = FindFirstObjectByType<CountScript>();
    }


    void Update()
    {
        //Clock for getting hungrier
        if (lastTicked + tickRate < Time.time)
        {
            updateStats();
            lastTicked = Time.time;
        }

        //Check if starving
        if (hunger > 100f)
        {
            if (isPred)
            {
                cS.UpdatePred(-1);
            } else if (!isPred)
            {
                cS.UpdatePrey(-1);
            }
            Destroy(gameObject);
        }

        //Decision making
        if (!busy)
        {
            if (hunger > 50f)
            {
                canMate = false;
                busy = true;
                GameObject food = findCLosestFood();
                if (food == null)
                {
                    return;
                }

                setDestination(food.transform.position);

                if (food.GetComponent<GOB>() != null)
                {
                    food.GetComponent<GOB>().hunted = true;
                }

                if (!startedHunt)
                {
                    huntStart = Time.time;
                }

                if (huntStart + huntTimeOut < Time.time)
                {
                    startedHunt = false;
                    busy = false;
                }
            }
            else if (hunger < 20)
            {
                canMate = true;
                busy = true;
                GameObject mate = findClosestMate();
                if (mate == null)
                {
                    busy = false;
                    return;
                }
                setDestination(mate.transform.position);
                
            }
        }
        
    }

    private void setDestination(Vector3 destination)
    {
        Vector3 agentPosition = transform.position;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(agentPosition, out hit, 3, NavMesh.AllAreas))
        {
            // Check if the positions are vertically aligned
            if (Mathf.Approximately(agentPosition.x, hit.position.x)
                && Mathf.Approximately(agentPosition.z, hit.position.z))
            {
                // Lastly, check if object is below navmesh
                if (agentPosition.y >= hit.position.y)
                {
                    agent.SetDestination(destination);
                }
            }
        }
    }

    void updateStats()
    {
        hunger += hungerRate;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(foodType))
        {
            Destroy(collision.gameObject);
            hunger = 0f;
            busy = false;
        }
        if (collision.gameObject.CompareTag(this.gameObject.tag) && canMate)
        {
            canMate = false;
            hunger += 30;
            busy = false;
            Instantiate(createWhenMating, transform.position, Quaternion.identity);
            if (isPred)
            {
                cS.UpdatePred(1);
            }
            else if (!isPred)
            {
                cS.UpdatePrey(1);
            }
        }

    }

    private GameObject findCLosestFood()
    {
        GameObject[] foodLocations = GameObject.FindGameObjectsWithTag(foodType);
        float distance = Mathf.Infinity;
        GameObject closestFood = null;
        foreach (GameObject food in foodLocations)
        {
            if (food.GetComponent<GOB>() != null)
            {
                if(food.GetComponent<GOB>().hunted)
                {
                    continue;
                }
            }
            if (Vector3.Distance(transform.position, food.transform.position) < distance)
            {
                distance = Vector3.Distance(transform.position, food.transform.position);
                closestFood = food;
            }
        }
        return closestFood;
    }

    private GameObject findClosestMate()
    {
        GameObject[] possibleMates = GameObject.FindGameObjectsWithTag(this.gameObject.tag);
        float distance = Mathf.Infinity;
        GameObject targetMate = null;
        foreach (GameObject possibleMate in possibleMates)
        {
            if (possibleMate.GetComponent<GOB>().canMate == false)
            {
                continue;
            }
            if (Vector3.Distance(transform.position, possibleMate.transform.position) < distance)
            {
                distance = Vector3.Distance(transform.position, possibleMate.transform.position);
                targetMate = possibleMate;
            }
        }

        return targetMate;
    }


}
