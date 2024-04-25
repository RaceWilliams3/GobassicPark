using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOB : MonoBehaviour
{
    public bool active;
    public bool busy;

    public float hungerRate;
    public float matingRate;

    public float tickRate = 5.0f;
    private float lastTicked = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lastTicked + tickRate < Time.time)
        {
            lastTicked = Time.time;
        }

    }

}
