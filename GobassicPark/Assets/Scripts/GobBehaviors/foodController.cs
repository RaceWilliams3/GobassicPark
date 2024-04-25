using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class foodController : MonoBehaviour
{
    public int growthRate;

    public void Start()
    {
        
    }
    void IEnumerator(int growthRate)
    {

    }
    public void grow()
    {

    }
    public void eaten()
    {
        GameObject.Destroy(gameObject);
    }
}
