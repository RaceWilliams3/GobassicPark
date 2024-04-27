using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class foodController : MonoBehaviour
{
    public int growthRate;
    private IEnumerator coroutine;
    public CountScript cS;

    public void Start()
    {
        cS = FindFirstObjectByType<CountScript>();
        print(growthRate + "Rate");
        coroutine = growTime(growthRate);
        StartCoroutine(coroutine);
    }
    private IEnumerator growTime(int growTime)
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
        cS.UpdateTree(1);
    }
    public void eaten()
    {
        cS.UpdateTree(-1);
        GameObject.Destroy(gameObject);
    }
}
