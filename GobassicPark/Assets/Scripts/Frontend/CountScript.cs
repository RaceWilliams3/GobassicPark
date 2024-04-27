using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountScript : MonoBehaviour
{
    public TMP_Text predCount;
    public TMP_Text preyCount;
    public TMP_Text treeCount;
    public int numberOfPred;
    public int numberOfPrey;
    public int numberOfTrees;


    public void UpdatePred(int input)
    {
        numberOfPred += input;
        numberOfPred = Mathf.Clamp(numberOfPred, 0, 1000000);
        predCount.text = "Predator Count: " + numberOfPred.ToString();
    }
    public void UpdatePrey(int input)
    {
        numberOfPrey += input;
        numberOfPred = Mathf.Clamp(numberOfPrey, 0, 1000000);
        preyCount.text = "Prey Count: " + numberOfPrey.ToString();
    }
    public void UpdateTree(int input)
    {
        numberOfTrees += input;
        numberOfPred = Mathf.Clamp(numberOfTrees, 0, 1000000);
        treeCount.text = "Tree Count: " + numberOfTrees.ToString();
    }


}
