using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class preyController : MonoBehaviour
{
    public int hungerRate;

    public void die()
    {
        GameObject.Destroy(gameObject);
    }
}
