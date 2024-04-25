using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class predatorController : MonoBehaviour
{
    public int hungerRate;

    public void die()
    {
        GameObject.Destroy(gameObject);
    }
}
