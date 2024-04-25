using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class foodController : MonoBehaviour
{
    public float growthRate;
    private IEnumerator coroutine;

    public void Start()
    {
        growthRate = 10.0f;
        coroutine = growTime(growthRate);
        StartCoroutine(coroutine);
    }
    private IEnumerator growTime(float growTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(growTime);
            grow();
        }
    }
    public void grow()
    {
        var position = new Vector3(UnityEngine.Random.Range(-18, 18), 1, UnityEngine.Random.Range(-18, 18));
        Instantiate(gameObject, position, Quaternion.identity);
    }
    public void eaten()
    {
        GameObject.Destroy(gameObject);
    }
}
