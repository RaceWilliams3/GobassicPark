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
        predCount.text = "Predator Count: " + numberOfPred.ToString();
    }
    public void UpdatePrey(int input)
    {
        numberOfPrey += input;
        preyCount.text = "Prey Count: " + numberOfPrey.ToString();
    }
    public void UpdateTree(int input)
    {
        numberOfTrees += input;
        treeCount.text = "Tree Count: " + numberOfTrees.ToString();
    }


}
