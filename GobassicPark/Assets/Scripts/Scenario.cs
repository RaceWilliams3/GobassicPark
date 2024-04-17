using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Scenario
{
    public int ID;
    public string Name;
    public int PredatorStartCount;
    public int PreyStartCount;
    public int FoodStartAmount;
    public int OverallHungerRate;
    public int FoodGenRate;
    public int PredatorType;
    public int PreyType;
}
